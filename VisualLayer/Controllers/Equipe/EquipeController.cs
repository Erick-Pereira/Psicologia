using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VisualLayer.Models.Equipe;

namespace VisualLayer.Controllers.Equipe
{
    public class EquipeController : Controller
    {
        private readonly IEquipeService _EquipeService;
        private readonly IMapper _mapper;

        public EquipeController(IEquipeService equipeService, IMapper mapper)
        {
            _EquipeService = equipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Equipes()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(EquipeInsertViewModel equipeInsert)
        {
            return View();
        }
    }
}