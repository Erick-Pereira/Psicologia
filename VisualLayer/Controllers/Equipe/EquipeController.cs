using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Equipes()
        {
            return View();
        }
    }
}