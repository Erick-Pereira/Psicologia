using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Criar(CargoInsertViewModel cargoInsert)
        {
            try
            {
                Entities.Cargo cargo = _mapper.Map<Entities.Cargo>(cargoInsert);
                _cargoService.Insert(cargo);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }

        }
    }
}