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
        private const string ENCRYPT = "ID";
        private const int NIVEL_PERMISSAO = 3;
        private readonly IEstadoService _estadoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public FuncionarioController(IWebHostEnvironment webHostEnvironment, IFuncionarioService funcionarioService, IEstadoService estadoService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _FuncionarioService = funcionarioService;
            _estadoService = estadoService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string cep)
        {
            CepAPI a = CepAPI.Busca(cep);
            ViewBag.Endereco = a;
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Configuracao()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(verify.ID).Result.Item;
            FuncionarioDetailViewModel funcionarioDetail = _mapper.Map<FuncionarioDetailViewModel>(funcionario);
            funcionarioDetail.Id = funcionarioDetail.Id.Encrypt(ENCRYPT);
            funcionarioDetail.Cep = funcionario.Endereco.CEP;
            funcionarioDetail.NumeroCasa = funcionario.Endereco.NumeroCasa;
            funcionarioDetail.Rua = funcionario.Endereco.Rua;
            funcionarioDetail.Complemento = funcionario.Endereco.Complemento;
            funcionarioDetail.Bairro = funcionario.Endereco.Bairro.NomeBairro;
            funcionarioDetail.Cidade = funcionario.Endereco.Bairro.Cidade.NomeCidade;
            funcionarioDetail.Estado = funcionario.Endereco.Bairro.Cidade.Estado.NomeEstado;
            return View(funcionarioDetail);
        }

        [Authorize]
        public async Task<IActionResult> Funcionarios()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            DataResponse<Entities.Funcionario> dataResponse = await _FuncionarioService.GetAllAtivos();
            List<FuncionarioSelectViewModel> Funcionarios = new List<FuncionarioSelectViewModel>();
            for (int i = 0; i < dataResponse.Data.Count; i++)
            {
                Funcionarios.Add(_mapper.Map<FuncionarioSelectViewModel>(dataResponse.Data[i]));
            }
            for (int i = 0; i < Funcionarios.Count; i++)
            {
                Funcionarios[i].Id = Funcionarios[i].Id.Encrypt(ENCRYPT);
            }
            return View(Funcionarios);
        }

        [Authorize]
        public IActionResult Index()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View();
        }

        [Route("api/Funcionario/JsonStringBody")]
        public string JsonStringBody([FromBody] string content)
        {
            return content;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT));
            SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(id);
            if (response.Item.IsFirstLogin)
            {
                FuncionarioUpdateViewModel funcionario = _mapper.Map<FuncionarioUpdateViewModel>(response.Item);
                funcionario.EstadoId = response.Item.Endereco.Bairro.Cidade.EstadoId;
                funcionario.Cep = response.Item.Endereco.CEP;
                funcionario.NumeroCasa = response.Item.Endereco.NumeroCasa;
                funcionario.Rua = response.Item.Endereco.Rua;
                funcionario.Complemento = response.Item.Endereco.Complemento;
                funcionario.Bairro = response.Item.Endereco.Bairro.NomeBairro;
                funcionario.Cidade = response.Item.Endereco.Bairro.Cidade.NomeCidade;
                List<Estado> estados = _estadoService.GetAll().Result.Data;
                ViewBag.Estados = estados;
                return View(funcionario);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(FuncionarioUpdateViewModel funcionarioUpdate)
        {
            Entities.Funcionario funcionario2 = _FuncionarioService.GetByID(Convert.ToInt32(funcionarioUpdate.Id)).Result.Item;
            funcionario2.Endereco = new Endereco() { Bairro = new Bairro() { Cidade = new Cidade() { Estado = new Estado() } } };
            funcionario2.Nome = funcionarioUpdate.Nome;
            funcionario2.Cpf = funcionarioUpdate.Cpf;
            funcionario2.Endereco.CEP = funcionarioUpdate.Cep;
            funcionario2.Endereco.Rua = funcionarioUpdate.Rua;
            funcionario2.Endereco.NumeroCasa = funcionarioUpdate.NumeroCasa;
            funcionario2.Endereco.Complemento = funcionarioUpdate.Complemento;
            funcionario2.Endereco.Bairro.NomeBairro = funcionarioUpdate.Bairro;
            funcionario2.Endereco.Bairro.Cidade.NomeCidade = funcionarioUpdate.Cidade;
            funcionario2.DataNascimento = funcionarioUpdate.DataNascimento;
            funcionario2.Endereco.Bairro.Cidade.EstadoId = funcionarioUpdate.EstadoId;
            funcionario2.Endereco.Bairro.Cidade.Estado = _estadoService.GetByID(funcionarioUpdate.EstadoId).Result.Item;
            Response response = await _FuncionarioService.UpdateFuncionario(funcionario2);
            if (response.HasSuccess)
            {
                if (funcionarioUpdate.Image.Length == 0)
                {
                    ViewBag.Errors = "imagem deve ser informada";
                }

                string ext = Path.GetExtension(funcionarioUpdate.Image.FileName);
                if (ext != ".jpg")
                {
                    ViewBag.Erros = "imagem deve ter as extensões .jpg, .png";
                }

                string path = webHostEnvironment.ContentRootPath + "\\SystemImg\\Funcionarios\\";
                using (FileStream fs = new FileStream(path + funcionarioUpdate.Cpf.StringCleaner() + ".jpg", FileMode.Create))
                {
                    await funcionarioUpdate.Image.CopyToAsync(fs);
                }

                if (funcionario2.Cargo.NivelPermissao == 3)
                    return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                if (funcionario2.Cargo.NivelPermissao == 1)
                    return RedirectToAction(actionName: "Index", controllerName: "RH");
                if (funcionario2.Cargo.NivelPermissao == 0)
                    return RedirectToAction(actionName: "Index", controllerName: "Adm");
            }
            return View();
        }
    }
}