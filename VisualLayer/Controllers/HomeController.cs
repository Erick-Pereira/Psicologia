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
using VisualLayer.Security;

namespace VisualLayer.Controllers
{
    public class HomeController : CustomController
    {
        private const string ENCRYPT = "ID";
        private readonly ICargoService _cargoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInicioService _InicioService;
        private readonly IMapper _mapper;

        public HomeController(IFuncionarioService funcionarioService, IMapper mapper, IInicioService inicioService, ICargoService cargoService, IHttpContextAccessor httpContextAccessor) : base(funcionarioService, httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _mapper = mapper;
            _InicioService = inicioService;
            _cargoService = cargoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid) != null)
                {
                    ViewBag.Funcionario = _mapper.Map<FuncionarioSelectViewModel>(_FuncionarioService.GetByID(await GetIdByCookie()).Result.Item);
                }
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        public async Task Logar(Entities.Funcionario funcionario)
        {
            try
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Sid, funcionario.ID.ToString().Encrypt(ENCRYPT)));
                claims.Add(new Claim(ClaimTypes.Name, funcionario.Nome));
                claims.Add(new Claim(ClaimTypes.Email, funcionario.Email));
                claims.Add(new Claim(ClaimTypes.Role, _cargoService.GetByID(funcionario.CargoID).Result.Item.Funcao));
                ClaimsPrincipal claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                AuthenticationProperties authProperties = new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(10), IssuedUtc = DateTime.Now };

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        public async Task<IActionResult> Logarr()
        {
            try
            {
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(await GetIdByCookie()).Result.Item;
                if (await _FuncionarioService.Logar(funcionario))
                {
                    funcionario.Cargo = _cargoService.GetByID(funcionario.CargoID).Result.Item;
                    if (funcionario.IsFirstLogin)
                        return RedirectToAction(actionName: "Update", controllerName: "Funcionario");
                    if (funcionario.HasRequiredTest)
                        return RedirectToAction(actionName: "sf36", controllerName: "Funcionario");
                    if (funcionario.Cargo.NivelPermissao == 0)
                        return RedirectToAction(actionName: "Index", controllerName: "Adm");
                    if (funcionario.Cargo.NivelPermissao == 1)
                        return RedirectToAction(actionName: "Index", controllerName: "RH");
                    if (funcionario.Cargo.NivelPermissao == 3)
                        return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                }
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                await _InicioService.Iniciar();
                login.Senha = login.Senha.Hash();
                Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(login);
                if (await _FuncionarioService.Logar(funcionario))
                {
                    funcionario = _FuncionarioService.GetByLogin(funcionario).Result.Item;
                    funcionario.Cargo = _cargoService.GetByID(funcionario.CargoID).Result.Item;

                    Logar(funcionario);

                    if (funcionario.IsFirstLogin)
                        return RedirectToAction(actionName: "Update", controllerName: "Funcionario");
                    if (funcionario.HasRequiredTest)
                        return RedirectToAction(actionName: "Sf36", controllerName: "Funcionario");
                    if (funcionario.Cargo.NivelPermissao == 0)
                        return RedirectToAction(actionName: "Index", controllerName: "Adm");
                    if (funcionario.Cargo.NivelPermissao == 1)
                        return RedirectToAction(actionName: "Index", controllerName: "RH");
                    if (funcionario.Cargo.NivelPermissao == 3)
                        return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                }
                ViewBag.Erro = "Email ou senha invalidos";
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Logoff()
        {
            try
            {
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Membros()
        {
            try
            {
                if (_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid) != null)

                {
                    ViewBag.Funcionario = _mapper.Map<FuncionarioSelectViewModel>(_FuncionarioService.GetByID(await GetIdByCookie()).Result.Item);
                }
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }
    }
}