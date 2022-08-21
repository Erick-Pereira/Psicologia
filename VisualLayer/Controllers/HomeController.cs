using AutoMapper;
using BusinessLogicalLayer.BLL;
using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisualLayer.Models;

namespace VisualLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IMapper _mapper;
        private readonly IInicioService _InicioService;

        public HomeController(IFuncionarioService funcionarioService, IMapper mapper, IInicioService inicioService)
        {
            _FuncionarioService = funcionarioService;
            _mapper = mapper;
            _InicioService = inicioService;
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
            _InicioService.Iniciar();
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(login);
            funcionario.Senha = funcionario.Senha.Hash();
            if (await _FuncionarioService.Logar(funcionario))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}