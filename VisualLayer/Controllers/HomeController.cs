using AutoMapper;
using BusinessLogicalLayer;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Diagnostics;
using VisualLayer.Models;

namespace VisualLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFuncionarioService _FuncionarioService;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Membros()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            Hash hash = new Hash();
            login.Senha = hash.ComputeSha256Hash(login.Senha);
            MapperConfiguration mapper = new MapperConfiguration(m =>
            m.CreateMap<LoginModel, Entities.Funcionario>()
        );

            Entities.Funcionario funcionario =
                mapper.CreateMapper().Map<Entities.Funcionario>(login);

            if (await _FuncionarioService.Logar(funcionario))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
            }
            return View();
        }

        public Task<DataResponse<Entities.Funcionario>> Select()
        {
            return _FuncionarioService.GetAll();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}