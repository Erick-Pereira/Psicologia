using Microsoft.AspNetCore.Mvc;

namespace VisualLayer.Controllers.Erro
{
    public class ErroController : Controller
    {
        public IActionResult Index(Exception ex)
        {
            ViewBag.Erro = ex.Message;
            return View();
        }
    }
}