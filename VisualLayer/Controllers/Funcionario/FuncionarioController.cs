using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(id);
            FuncionarioUpdateViewModel funcionario = _mapper.Map<FuncionarioUpdateViewModel>(response.Item);
            return View(funcionario);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(FuncionarioUpdateViewModel funcionarioUpdate)
        {
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(funcionarioUpdate);
            Response response = await _FuncionarioService.Update(funcionario);
            if (response.HasSuccess)
            {
                if (funcionario.Cargo.NivelPermissao == 3)
                    return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                if (funcionario.Cargo.NivelPermissao == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Adm");
            }
            return View();
        }
    }
}