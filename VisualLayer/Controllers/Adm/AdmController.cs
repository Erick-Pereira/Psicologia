using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Security.Claims;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Adm
{
    public class AdmController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly ICargoService _CargoService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdmController(IFuncionarioService funcionarioService, ICargoService cargoService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _CargoService = cargoService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<IActionResult> Editar(int id)
        {
            ViewBag.Funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(id).Result.Item);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Editar(FuncionarioUpdateAdmViewModel model)
        {
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(model);
            Response response = await _FuncionarioService.UpdateAdm(funcionario);
            if (!response.HasSuccess)
            {
                ViewBag.Erros = response.Message;
            }
            return View();
        }

        public async Task<IActionResult> RequisitarUpdate(int id)
        {
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(id).Result.Item;
            Response response = await _FuncionarioService.RequistarUpdate(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        public async Task<IActionResult> Detalhar(int id)
        {
            return View(_mapper.Map<FuncionarioDetailViewModel>(_FuncionarioService.GetByID(id).Result.Item));
        }

        public async Task<IActionResult> Deletar(int id)
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            if (id == userId)
            {
                ViewBag.Erros = "Você não pode se deletar";
            }
            return View();
        }

        public async Task<IActionResult> Desativar(int id)
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            if (id == userId)
            {
                ViewBag.Erros = "Você não pode se desativar";
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(id).Result.Item;
            funcionario.IsAtivo = false;
            Response response = await _FuncionarioService.Update(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
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