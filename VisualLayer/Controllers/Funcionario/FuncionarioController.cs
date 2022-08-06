using AutoMapper;
using BusinessLogicalLayer;
using Microsoft.AspNetCore.Mvc;
using Shared;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}