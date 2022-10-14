using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VisualLayer.Models.Cargo;
using VisualLayer.Security;

namespace VisualLayer.Controllers.Cargo
{
    public class CargoController : CustomController
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService, IMapper mapper, IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor) : base(funcionarioService, httpContextAccessor)
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
                return ThrowError(ex);
            }
        }
    }
}