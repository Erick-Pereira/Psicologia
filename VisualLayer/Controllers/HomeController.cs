using BusinessLogicalLayer;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Diagnostics;
using VisualLayer.Models;

namespace VisualLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
        public IActionResult Login(LoginModel login)
        {
            Hash hash = new Hash();
            login.Senha = hash.ComputeSha256Hash(login.Senha);
            FuncionarioService funcionarioService = new FuncionarioService();
            Entities.Funcionario funcionario = new()
            {
                Email = login.Email,
                Senha = login.Senha,
            };
            if (funcionarioService.GetByLogin(funcionario).Item == 1)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
            }
            return View();
        }

        public DataResponse<Entities.Funcionario> Select()
        {
            FuncionarioService funcionarioBLL = new FuncionarioService();
            return funcionarioBLL.GetAll();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}