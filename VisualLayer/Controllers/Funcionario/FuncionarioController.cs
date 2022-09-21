using AutoMapper;
using BusinessLogicalLayer.API;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using VisualLayer.Models.Funcionario;
using VisualLayer.Security;

namespace VisualLayer.Controllers.Funcionario
{
    public class FuncionarioController : CustomController
    {
        private const string ENCRYPT = "ID";
        private const int NIVEL_PERMISSAO = 3;
        private readonly IEstadoService _estadoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ISF36Service _sf36Service;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FuncionarioController(IEstadoService estadoService, IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor, IMapper mapper, ISF36Service sf36Service, IWebHostEnvironment hostEnvironment) : base(funcionarioService, httpContextAccessor)
        {
            _estadoService = estadoService;
            _FuncionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _sf36Service = sf36Service;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSenha(string senha)
        {
            try
            {
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(await GetIdByCookie()).Result.Item;
                funcionario.Senha = senha.Hash();
                Response response = await _FuncionarioService.AlterarSenha(funcionario);
                JsonResult result = Json(response);
                return result;
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string cep)

        {
            try
            {
                CepAPI a = CepAPI.Busca(cep);
                ViewBag.Endereco = a;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Configuracao()
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(await GetIdByCookie()).Result.Item;
                FuncionarioDetailViewModel funcionarioDetail = _mapper.Map<FuncionarioDetailViewModel>(funcionario);
                funcionarioDetail.Id = funcionarioDetail.Id.Encrypt(ENCRYPT);
                funcionarioDetail.Cep = funcionario.Endereco.CEP;
                funcionarioDetail.NumeroCasa = funcionario.Endereco.NumeroCasa;
                funcionarioDetail.Rua = funcionario.Endereco.Rua;
                funcionarioDetail.Complemento = funcionario.Endereco.Complemento;
                funcionarioDetail.Bairro = funcionario.Endereco.Bairro.NomeBairro;
                funcionarioDetail.Cidade = funcionario.Endereco.Bairro.Cidade.NomeCidade;
                funcionarioDetail.Estado = funcionario.Endereco.Bairro.Cidade.Estado.NomeEstado;
                string caminho_WebRoot = _hostEnvironment.WebRootPath;
                string path = Path.Combine(caminho_WebRoot, $"SystemImg\\Funcionarios\\{funcionario.Cpf.StringCleaner()}");
                funcionarioDetail.Foto = $"/SystemImg/Funcionarios/{funcionario.Cpf.StringCleaner()}.jpg";
                return View(funcionarioDetail);
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Funcionarios()
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
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
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [Route("api/Funcionario/JsonStringBody")]
        public string JsonStringBody([FromBody] string content)
        {
            return content;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SF36()
        {
            try
            {
                SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(await GetIdByCookie());
                if (response.Item.HasRequiredTest)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(actionName: "Logarr", controllerName: "home");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SF36(FuncionarioRespostasQuestionarioSf36 respostas)
        {
            try
            {
                Response response = await _sf36Service.CalcularScore(respostas);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update()
        {
            try
            {
                SingleResponse<Entities.Funcionario> response = await _FuncionarioService.GetByID(await GetIdByCookie());
                if (response.Item.IsFirstLogin)
                {
                    FuncionarioUpdateViewModel funcionario = _mapper.Map<FuncionarioUpdateViewModel>(response.Item);
                    funcionario.EstadoUf = response.Item.Endereco.Bairro.Cidade.Estado.Sigla;
                    funcionario.Cep = response.Item.Endereco.CEP;
                    funcionario.NumeroCasa = response.Item.Endereco.NumeroCasa;
                    funcionario.Rua = response.Item.Endereco.Rua;
                    funcionario.Complemento = response.Item.Endereco.Complemento;
                    funcionario.Bairro = response.Item.Endereco.Bairro.NomeBairro;
                    funcionario.Cidade = response.Item.Endereco.Bairro.Cidade.NomeCidade;
                    string caminho_WebRoot = _hostEnvironment.WebRootPath;
                    string path = Path.Combine(caminho_WebRoot, $"SystemImg\\Funcionarios\\{funcionario.Cpf.StringCleaner()}");
                    funcionario.Foto = $"/SystemImg/Funcionarios/{funcionario.Cpf.StringCleaner()}.jpg";
                    List<Estado> estados = _estadoService.GetAll().Result.Data;
                    ViewBag.Estados = estados;
                    return View(funcionario);
                }
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(FuncionarioUpdateViewModel funcionarioUpdate)
        {
            try
            {
                Entities.Funcionario funcionario2 = _FuncionarioService.GetByID(Convert.ToInt32(funcionarioUpdate.Id)).Result.Item;
                funcionario2.Nome = funcionarioUpdate.Nome;
                funcionario2.Cpf = funcionarioUpdate.Cpf;
                funcionario2.Endereco.Bairro.Cidade.Estado = _estadoService.GetByUF(funcionarioUpdate.EstadoUf).Result.Item;
                funcionario2.Endereco.Bairro.Cidade.EstadoId = funcionario2.Endereco.Bairro.Cidade.Estado.ID;
                funcionario2.Endereco.Bairro.Cidade.NomeCidade = funcionarioUpdate.Cidade;
                funcionario2.Endereco.Bairro.NomeBairro = funcionarioUpdate.Bairro;
                funcionario2.Endereco.Complemento = funcionarioUpdate.Complemento;
                funcionario2.Endereco.NumeroCasa = funcionarioUpdate.NumeroCasa;
                funcionario2.Endereco.CEP = funcionarioUpdate.Cep.StringCleaner();
                funcionario2.Endereco.Rua = funcionarioUpdate.Rua;
                funcionario2.DataNascimento = funcionarioUpdate.DataNascimento;
                funcionario2.Genero = funcionarioUpdate.Genero;
                funcionario2.EstadoCivil = funcionarioUpdate.EstadoCivil;
                Response response = await _FuncionarioService.UpdateFuncionario(funcionario2);
                if (response.HasSuccess)
                {
                    if (funcionarioUpdate.Image != null)
                    {
                        if (funcionarioUpdate.Image.Length != 0)
                        {
                            string ext = Path.GetExtension(funcionarioUpdate.Image.FileName);
                            if (ext != ".jpg" && ext != ".png")
                            {
                                ViewBag.Erros = "imagem deve ter as extensões .jpg, .png";
                                List<Estado> estados = _estadoService.GetAll().Result.Data;
                                ViewBag.Estados = estados;
                                return RedirectToAction(actionName: "Update");
                            }
                            string caminho_WebRoot = _hostEnvironment.WebRootPath;
                            string path = Path.Combine(caminho_WebRoot, "SystemImg\\Funcionarios\\");
                            using (FileStream fs = new FileStream(path + funcionarioUpdate.Cpf.StringCleaner() + ".jpg", FileMode.Create))
                            {
                                await funcionarioUpdate.Image.CopyToAsync(fs);
                            }
                        }
                    }
                    if (funcionario2.Cargo.NivelPermissao == 3)
                        return RedirectToAction(actionName: "Index", controllerName: "Funcionario");
                    if (funcionario2.Cargo.NivelPermissao == 1)
                        return RedirectToAction(actionName: "Index", controllerName: "RH");
                    if (funcionario2.Cargo.NivelPermissao == 0)
                        return RedirectToAction(actionName: "Index", controllerName: "Adm");
                }
                return RedirectToAction(actionName: "Update");
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Erro", ex);
            }
        }
    }
}