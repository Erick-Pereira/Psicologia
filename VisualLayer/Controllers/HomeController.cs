using BusinessLogicalLayer;
using Entities;
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

        public IActionResult Login()
        {
            return View();
        }

        public DataResponse<Funcionario> Select()
        {
            FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
            return funcionarioBLL.GetAll();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}