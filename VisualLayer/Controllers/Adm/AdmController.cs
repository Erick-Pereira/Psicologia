using AutoMapper;
using Shared.Extensions;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Adm
{
    public class AdmController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly ICargoService _CargoService;
        private readonly IMapper _mapper;

        public AdmController(IFuncionarioService funcionarioService, IMapper mapper, ICargoService cargoService)
        {
            _CargoService = cargoService;
            _FuncionarioService = funcionarioService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Criar()
        {
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(id).Result.Item);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(FuncionarioUpdateAdmViewModel model)
        {
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(model);
            Response response = await _FuncionarioService.Update(funcionario);
            if (!response.HasSuccess)
            {
                ViewBag.Erros = response.Message;
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Criar(FuncionarioInsertViewModel funcionarioInsert)
        {
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(funcionarioInsert);
            Response response = await _FuncionarioService.Insert(funcionario);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            ViewBag.Errors = response.Message;
            return View();
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Calendario()
        {
            return View();
        }
    }
}