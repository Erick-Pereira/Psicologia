using Microsoft.AspNetCore.Mvc;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index(Entities.Funcionario funcionario)
        {
            return View(funcionario);
        }
    }
}
