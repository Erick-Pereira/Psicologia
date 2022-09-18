using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using System.Security.Claims;
using VisualLayer.Models.Cargo;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Controllers.Adm
{
    public class AdmController : Controller
    {
        private const string ENCRYPT = "ID";
        private const int NIVEL_PERMISSAO = 0;
        private readonly ICargoService _CargoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public AdmController(ICargoService cargoService, IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _CargoService = cargoService;
            _FuncionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }

        [Authorize]
        public async Task<IActionResult> Analises()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Ativar(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item;
            funcionario.IsAtivo = false;
            Response response = await _FuncionarioService.Ativar(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cadastrar()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            List<Entities.Cargo> cargos = _CargoService.GetAll().Result.Data;
            ViewBag.Cargos = cargos;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cadastrar(FuncionarioInsertViewModel funcionarioInsert)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(funcionarioInsert);
            Response response = await _FuncionarioService.Insert(funcionario);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            ViewBag.Errors = response.Message;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Calendario()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cargo()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cargo(CargoInsertViewModel cargoViewModel)
        {
            Entities.Cargo cargo = _mapper.Map<Entities.Cargo>(cargoViewModel);
            Response response = _CargoService.Insert(cargo).Result;
            ViewBag.Erros = response.Message;
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Configuracao()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
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
            string caminho_WebRoot = hostEnvironment.WebRootPath;
            string path = Path.Combine(caminho_WebRoot, $"SystemImg\\Funcionarios\\{funcionario.Cpf.StringCleaner()}");
            funcionarioDetail.Foto = $"/SystemImg/Funcionarios/{funcionario.Cpf.StringCleaner()}.jpg";
            return View(funcionarioDetail);
        }

        [Authorize]
        public async Task<IActionResult> Deletar(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value);
            if (Convert.ToInt32(id.Decrypt(ENCRYPT)) == userId)
            {
                ViewBag.Erros = "Você não pode se deletar";
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Desativar(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            int identity = Convert.ToInt32(id.Decrypt(ENCRYPT));
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT));
            if (identity == userId)
            {
                ViewBag.Erros = "Você não pode se desativar";
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(identity).Result.Item;
            funcionario.IsAtivo = false;
            Response response = await _FuncionarioService.Desativar(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Detalhar(string id)
        {
            string con = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value;
            int identity = Convert.ToInt32(id.Decrypt(ENCRYPT));
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(identity);
            Entities.Funcionario funcionario = response.Item;
            FuncionarioDetailViewModel funcionarioDetail = _mapper.Map<FuncionarioDetailViewModel>(funcionario);
            funcionarioDetail.Id = funcionarioDetail.Id.Encrypt(ENCRYPT);
            funcionarioDetail.Cep = funcionario.Endereco.CEP;
            funcionarioDetail.NumeroCasa = funcionario.Endereco.NumeroCasa;
            funcionarioDetail.Rua = funcionario.Endereco.Rua;
            funcionarioDetail.Complemento = funcionario.Endereco.Complemento;
            funcionarioDetail.Bairro = funcionario.Endereco.Bairro.NomeBairro;
            funcionarioDetail.Cidade = funcionario.Endereco.Bairro.Cidade.NomeCidade;
            funcionarioDetail.Estado = funcionario.Endereco.Bairro.Cidade.Estado.NomeEstado;
            string caminho_WebRoot = hostEnvironment.WebRootPath;
            string path = Path.Combine(caminho_WebRoot, $"SystemImg\\Funcionarios\\{funcionario.Cpf.StringCleaner()}");
            funcionarioDetail.Foto = $"/SystemImg/Funcionarios/{funcionario.Cpf.StringCleaner()}.jpg";
            return View(funcionarioDetail);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Editar(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            FuncionarioUpdateAdmViewModel funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);
            if (verify.ID.ToString() == funcionario.Id)
            {
                return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
            }
            funcionario.Id = funcionario.Id.Encrypt(ENCRYPT);
            ViewBag.Funcionario = funcionario;
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Editar(FuncionarioUpdateAdmViewModel model)
        {
            model.Id = model.Id.Decrypt(ENCRYPT);
            Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(model);
            Response response = await _FuncionarioService.UpdateAdm(funcionario);
            if (response.HasSuccess)
            {
                return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
            }
            else
            {
                ViewBag.Funcionario = funcionario;
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                ViewBag.Erros = response.Message;
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Funcionarios()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            DataResponse<Entities.Funcionario> dataResponse = await _FuncionarioService.GetAll();
            List<FuncionarioSelectViewModel> Funcionarios = new List<FuncionarioSelectViewModel>();
            for (int i = 0; i < dataResponse.Data.Count; i++)
            {
                Funcionarios.Add(_mapper.Map<FuncionarioSelectViewModel>(dataResponse.Data[i]));
            }
            for (int i = 0; i < Funcionarios.Count; i++)
            {
                Funcionarios[i].Id = Funcionarios[i].Id.Encrypt(ENCRYPT);
            }
            ViewBag.ID = verify.ID.ToString().Encrypt(ENCRYPT);
            return View(Funcionarios);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> RequisitarUpdate(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item;
            Response response = await _FuncionarioService.RequistarUpdate(funcionario);
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }

        [Authorize]
        public async Task<IActionResult> ResetarSenha(string id)
        {
            Entities.Funcionario verify = _FuncionarioService.GetInformationToVerify(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Sid).Value.Decrypt(ENCRYPT))).Result.Item;
            if (verify.Cargo.NivelPermissao != NIVEL_PERMISSAO || verify.IsFirstLogin || verify.HasRequiredTest)
            {
                return RedirectToAction(actionName: "Logarr", controllerName: "Home");
            }
            _FuncionarioService.ResetarSenha(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);
            ViewBag.Funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);
            ViewBag.Cargos = _CargoService.GetAll().Result.Data;
            return RedirectToAction(actionName: "Funcionarios", controllerName: "Adm");
        }
    }
}