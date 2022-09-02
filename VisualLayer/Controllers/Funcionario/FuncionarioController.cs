using AutoMapper;
using BusinessLogicalLayer.API;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using System.Security.Claims;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _FuncionarioService;
        private readonly ICargoService _CargoService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FuncionarioController(IFuncionarioService funcionarioService, ICargoService cargoService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _CargoService = cargoService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<IActionResult> Update()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(id);
            FuncionarioUpdateViewModel funcionario = _mapper.Map<FuncionarioUpdateViewModel>(response.Item);
            return View(funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string cep)
        {
            CepAPI a = CepAPI.Busca(cep);
            ViewBag.Endereco = a;
            return View();
        }

        [Route("api/Funcionario/JsonStringBody")]
        public string JsonStringBody([FromBody] string content)
        {
            return content;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(FuncionarioUpdateViewModel funcionarioUpdate)
        {
            Entities.Funcionario funcionario2 = _FuncionarioService.GetByID(funcionarioUpdate.Id).Result.Item;
            funcionario2.Endereco = new Endereco() { Bairro = new Bairro() { Cidade = new Cidade() { Estado = new Estado() } } };
            funcionario2.Nome = funcionarioUpdate.Nome;
            funcionario2.Senha = funcionarioUpdate.Senha.Hash();
            funcionario2.Cpf = funcionarioUpdate.Cpf;
            funcionario2.Endereco.CEP = funcionarioUpdate.Cep;
            funcionario2.Endereco.Rua = funcionarioUpdate.Rua;
            funcionario2.Endereco.Complemento = funcionarioUpdate.Complemento;
            funcionario2.Endereco.Bairro.NomeBairro = funcionarioUpdate.Bairro;
            funcionario2.Endereco.Bairro.Cidade.NomeCidade = funcionarioUpdate.Cidade;
            funcionario2.Endereco.Bairro.Cidade.Estado.Sigla = funcionarioUpdate.Estado;
            funcionario2.DataNascimento = funcionarioUpdate.DataNascimento;
            Response response = await _FuncionarioService.Update(funcionario2);
            if (response.HasSuccess)
            {
                if (funcionario2.Cargo.NivelPermissao == 3)
                    return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                if (funcionario2.Cargo.NivelPermissao == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Adm");
            }
            return View();
        }
    }
}