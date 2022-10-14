using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Extensions;
using System.Diagnostics;
using VisualLayer.Models;
using VisualLayer.Models.Cargo;
using VisualLayer.Models.Funcionario;
using VisualLayer.Security;

namespace VisualLayer.Controllers.RH
{
    public class GraficoModel
    {
        public int Porcentagem { get; set; }
        public string TituloRodape { get; set; }
    }

    public class RhController : CustomController
    {
        private const string ENCRYPT = "ID";
        private const int NIVEL_PERMISSAO = 1;
        private readonly ICargoService _CargoService;
        private readonly IFuncionarioService _FuncionarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ISF36Service _sf36;
        private readonly IWebHostEnvironment hostEnvironment;

        public RhController(ICargoService cargoService, IFuncionarioService funcionarioService, IHttpContextAccessor httpContextAccessor, IMapper mapper, IWebHostEnvironment hostEnvironment, ISF36Service sf36) : base(funcionarioService, httpContextAccessor)
        {
            _CargoService = cargoService;
            _FuncionarioService = funcionarioService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _sf36 = sf36;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSenha(string senha)
        {
            try
            {
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(await GetIdByCookie()).Result.Item;
                funcionario.Senha = senha.Hash();
                Response response = await _FuncionarioService.AlterarSenha(funcionario);
                JsonResult result = Json(response.Message);
                return result;
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Analises()
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
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Ativar(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item;
                funcionario.IsAtivo = false;
                Response response = await _FuncionarioService.Ativar(funcionario);
                return RedirectToAction(actionName: "Funcionarios");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cadastrar()
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cadastrar(FuncionarioInsertViewModel funcionarioInsert)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(funcionarioInsert);
                Response response = await _FuncionarioService.Insert(funcionario);
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                ViewBag.Errors = response.Message;
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Calendario()
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
                return ThrowError(ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cargo()
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
                return ThrowError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cargo(CargoInsertViewModel cargoViewModel)
        {
            try
            {
                Entities.Cargo cargo = _mapper.Map<Entities.Cargo>(cargoViewModel);
                Response response = _CargoService.Insert(cargo).Result;
                ViewBag.Erros = response.Message;
                return RedirectToAction(actionName: "Cadastrar");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpGet("/RH/CarregaGrafico")]
        public async Task<JsonResult> CarregaGrafico(string id)
        {
            //int[] valore = { 67, 11, 98, 33, 1, 34, 66, 12, 90, 99, 7, 12, 44 };
            //var dados = new List<GraficoModel>();
            //for (int i = 0; i < 8; i++)
            //{
            //    dados.Add(new GraficoModel
            //    {
            //        TituloRodape = string.Concat(" Sim - ", i.ToString()),
            //        Porcentagem = valore[i]
            //    });
            //}
            //return Json(new { dados = dados });
            DataResponse<SF36Score> response = await _sf36.GetLast3SFByFuncionario(Convert.ToInt32(id.Decrypt(ENCRYPT)));
            List<SF36Score> scores = response.Data;
            SF36Score score = scores[0];
            string[] titulos = { "Dor", "Estado geral de Saúde", "Capacidade Funcional", "Vitalidade", "Saúde Mental", "Limitação por Aspectos Fisicos", "Limitação por Aspectos Emocionais", "Aspectos Sociais", score.ComparacaoSaude };
            double[] valores = { score.Dor, score.EstadoSaude, score.CapacidadeFuncional, score.Vitalidade, score.SaudeMental, score.LimitacaoAspectosFisicos, score.AspectosEmocionais, score.AspectosSociais };

            var dados = new List<GraficoModel>();

            for (int i = 0; i < 8; i++)
            {
                dados.Add(new GraficoModel
                {
                    TituloRodape = titulos[i],
                    Porcentagem = Convert.ToInt32(valores[i])
                });
            }

            return Json(new { dados = dados });
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
                string caminho_WebRoot = hostEnvironment.WebRootPath;
                string path = Path.Combine(caminho_WebRoot, $"SystemImg\\Funcionarios\\{funcionario.Cpf.StringCleaner()}");
                funcionarioDetail.Foto = $"/SystemImg/Funcionarios/{funcionario.Cpf.StringCleaner()}.jpg";
                return View(funcionarioDetail);
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                int userId = await GetIdByCookie();
                if (Convert.ToInt32(id.Decrypt(ENCRYPT)) == userId)
                {
                    ViewBag.Erros = "Você não pode se deletar";
                }
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> Desativar(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                int identity = Convert.ToInt32(id.Decrypt(ENCRYPT));
                int userId = await GetIdByCookie();
                if (identity == userId)
                {
                    ViewBag.Erros = "Você não pode se desativar";
                }
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(identity).Result.Item;
                funcionario.IsAtivo = false;
                Response response = await _FuncionarioService.Desativar(funcionario);
                return RedirectToAction(actionName: "Funcionarios");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Detalhar(string id)
        {
            try
            {
                int identity = Convert.ToInt32(id.Decrypt(ENCRYPT));
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
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
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Editar(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                FuncionarioUpdateAdmViewModel funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);
                int userId = await GetIdByCookie();
                if (userId.ToString() == funcionario.Id)
                {
                    return RedirectToAction(actionName: "Funcionarios");
                }
                funcionario.Id = funcionario.Id.Encrypt(ENCRYPT);
                ViewBag.Funcionario = funcionario;
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Editar(FuncionarioUpdateAdmViewModel model)
        {
            try
            {
                model.Id = model.Id.Decrypt(ENCRYPT);
                Entities.Funcionario funcionario = _mapper.Map<Entities.Funcionario>(model);
                Response response = await _FuncionarioService.UpdateAdm(funcionario);
                if (response.HasSuccess)
                {
                    return RedirectToAction(actionName: "Funcionarios");
                }
                ViewBag.Funcionario = funcionario;
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                ViewBag.Erros = response.Message;
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                int userId = await GetIdByCookie();
                ViewBag.ID = userId.ToString().Encrypt(ENCRYPT);
                return View(Funcionarios);
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        public async Task<IActionResult> Grafico(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                return View((object)id);
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
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
                return ThrowError(ex);
            }
        }

        public async Task<IActionResult> Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> RequisitarTeste(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item;
                Response response = await _FuncionarioService.RequistarTeste(funcionario);
                return RedirectToAction(actionName: "Funcionarios");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> RequisitarUpdate(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }
                Entities.Funcionario funcionario = _FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item;
                Response response = await _FuncionarioService.RequistarUpdate(funcionario);
                return RedirectToAction(actionName: "Funcionarios");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }

        [Authorize]
        public async Task<IActionResult> ResetarSenha(string id)
        {
            try
            {
                IActionResult result = await Authorize(NIVEL_PERMISSAO);
                if (result != null)
                {
                    return result;
                }

                _FuncionarioService.ResetarSenha(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);

                ViewBag.Funcionario = _mapper.Map<FuncionarioUpdateAdmViewModel>(_FuncionarioService.GetByID(Convert.ToInt32(id.Decrypt(ENCRYPT))).Result.Item);
                ViewBag.Cargos = _CargoService.GetAll().Result.Data;
                return RedirectToAction(actionName: "Funcionarios");
            }
            catch (Exception ex)
            {
                return ThrowError(ex);
            }
        }
    }
}