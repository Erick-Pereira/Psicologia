using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VisualLayer.Models;

namespace VisualLayer.Controllers.RH
{
    public class GraphicController : Controller
    {
        private readonly ILogger<GraphicController> _logger;

        public GraphicController(ILogger<GraphicController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/Home/CarregaGrafico")]
        //public JsonResult CarregaGrafico()
        //{
        //    double[] funcionarioScore = { 67, 11, 98, 33, 1, 34, 66, 12, 90, 99, 7, 12, 44 };

        //    var dados = new List<SF36Score>();

        //    for (int i = 0; i < 8; i++)
        //    {
        //        dados.Add(new SF36Score
        //        {
        //            TituloRodape = string.Concat(" Sim - ", i.ToString()),
        //            Porcentagem = valore[i]
        //        });
        //    }

        //    return Json(new { dados = dados });

        //}
        public IActionResult Grafico()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
