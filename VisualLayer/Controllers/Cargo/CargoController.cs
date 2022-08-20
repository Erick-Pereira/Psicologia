using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VisualLayer.Models.Cargo;

namespace VisualLayer.Controllers.Cargo
{
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService, IMapper mapper)
        {
            _cargoService = cargoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(CargoInsertViewModel cargoInsert)
        {
            Entities.Cargo cargo = _mapper.Map<Entities.Cargo>(cargoInsert);
            _cargoService.Insert(cargo);
            return View();
        }
    }
}