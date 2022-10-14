using Microsoft.AspNetCore.Mvc;
using Shared;

namespace VisualLayer.Controllers.Erro
{
    public class ErroController : Controller
    {
        public IActionResult Index(Response ex)
        {
            ViewBag.Erro = ex.Message;
            return View();
        }
    }
}