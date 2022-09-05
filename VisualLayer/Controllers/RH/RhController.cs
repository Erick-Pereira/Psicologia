using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using System.Security.Claims;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.RH
{
    public class RhController : Controller
    {
        private readonly ICargoService _CargoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RhController(IFuncionarioService funcionarioService, ICargoService cargoService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _CargoService = cargoService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Ativar(string id)
        {
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item;
            funcionario.IsAtivo = false;
            Response response = await _FuncionarioService.Ativar(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        [Authorize]
        public async Task<IActionResult> Calendario()
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

        public async Task<IActionResult> Deletar(string id)
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            if (Convert.ToInt32(id.Decrypt("ID")) == userId)
            {
                ViewBag.Erros = "Você não pode se deletar";
            }
            return View();
        }

        public async Task<IActionResult> Desativar(string id)
        {
            int identity = Convert.ToInt32(id.Decrypt("ID"));
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            if (identity == userId)
            {
                ViewBag.Erros = "Você não pode se desativar";
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(identity).Result.Item;
            funcionario.IsAtivo = false;
            Response response = await _FuncionarioService.Desativar(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        public async Task<IActionResult> Detalhar(string id)
        {
            FuncionarioDetailViewModel funcionario = _mapper.Map<FuncionarioDetailViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item);
            funcionario.Id = funcionario.Id.Encrypt("ID");
            return View(funcionario);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Editar(string id)
        {
            FuncionarioUpdateAdmViewModel funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item);
            funcionario.Id = funcionario.Id.Encrypt("ID");
            ViewBag.Funcionario = funcionario;
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

        [Authorize]
        public async Task<IActionResult> Funcionarios()
        {
            DataResponse<Entities.Funcionario> dataResponse = await _FuncionarioService.GetAll();
            List<FuncionarioSelectViewModel> Funcionarios = new List<FuncionarioSelectViewModel>();
            for (int i = 0; i < dataResponse.Data.Count; i++)
            {
                Funcionarios.Add(_mapper.Map<FuncionarioSelectViewModel>(dataResponse.Data[i]));
            }
            for (int i = 0; i < Funcionarios.Count; i++)
            {
                Funcionarios[i].Id = Funcionarios[i].Id.Encrypt("ID");
            }
            return View(Funcionarios);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> RequisitarUpdate(string id)
        {
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item;
            Response response = await _FuncionarioService.ResetarSenha(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        public async Task<IActionResult> ResetarSenha(string id)
        {
            _FuncionarioService.ResetarSenha(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item);
            ViewBag.Funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt("ID"))).Result.Item);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }
    }
}