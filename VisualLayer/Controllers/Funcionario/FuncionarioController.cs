using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly ICargoService _CargoService;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper, ICargoService cargoService)
        {
            _CargoService = cargoService;
            _FuncionarioService = funcionarioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(FuncionarioInsertViewModel funcionarioInsert)
        {
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(funcionarioInsert);
            _FuncionarioService.Insert(funcionario);
            return View();
        }

        public async Task<IActionResult> Funcionarios()
        {
            DataResponse<Entities.Funcionario> dataResponse = await _FuncionarioService.GetAll();
            List<FuncionarioSelectViewModel> Funcionarios = new List<FuncionarioSelectViewModel>();
            for (int i = 0; i < dataResponse.Data.Count; i++)
            {
                Funcionarios.Add(_mapper.Map<FuncionarioSelectViewModel>(dataResponse.Data[i]));
            }
            return View(Funcionarios);
        }
    }
}