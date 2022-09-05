using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using System.Diagnostics;
using System.Security.Claims;
using VisualLayer.Models;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IMapper _mapper;
        private readonly IInicioService _InicioService;
        private readonly ICargoService _cargoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IFuncionarioService funcionarioService, IMapper mapper, IInicioService inicioService, ICargoService cargoService, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _mapper = mapper;
            _InicioService = inicioService;
            _cargoService = cargoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            int id = 0;
            if (_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid) != null)
            {
                id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
                ViewBag.Funcionario = _mapper.Map<FuncionarioSelectViewModel>(_FuncionarioService.GetByID(id).Result.Item);
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Membros()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            _InicioService.Iniciar();
            login.Senha = login.Senha.Hash();
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(login);
            if (await _FuncionarioService.Logar(funcionario))
            {
                funcionario = _FuncionarioService.GetByLogin(funcionario).Result.Item;
                Logar(funcionario);
                if (funcionario.IsFirstLogin)
                    return RedirectToAction(actionName: "Update", controllerName: "Funcionario", funcionario.ID);
                if (funcionario.HasRequiredTest) { }
                if (funcionario.Cargo.NivelPermissao == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Adm");
                if (funcionario.Cargo.NivelPermissao == 3)
                    return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
            }
            return View();
        }

        public async Task<IActionResult> Logarr()
        {
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value)).Result.Item;
            if (await _FuncionarioService.Logar(funcionario))
            {
                funcionario = _FuncionarioService.GetByLogin(funcionario).Result.Item;
                funcionario.Cargo = _cargoService.GetByID(funcionario.CargoID).Result.Item;
                if (funcionario.IsFirstLogin)
                    return RedirectToAction(actionName: "Update", controllerName: "Funcionario", funcionario.ID);
                if (funcionario.Cargo.NivelPermissao == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Adm");
                if (funcionario.Cargo.NivelPermissao == 3)
                    return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public async Task Logar(Entities.Funcionario funcionario)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, funcionario.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, funcionario.Nome));
            claims.Add(new Claim(ClaimTypes.Email, funcionario.Email));
            claims.Add(new Claim(ClaimTypes.Hash, funcionario.Senha));
            claims.Add(new Claim(ClaimTypes.Role, _cargoService.GetByID(funcionario.CargoID).Result.Item.Funcao));
            ClaimsPrincipal claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            AuthenticationProperties authProperties = new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(10), IssuedUtc = DateTime.Now };
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        [Authorize]
        public async Task<IActionResult> Logoff()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}