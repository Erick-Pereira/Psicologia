using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class InicioService : IInicioService
    {
        private readonly IBairroService _bairroService;
        private readonly ICargoService _cargoService;
        private readonly ICidadeService _cidadeService;
        private readonly IEnderecoService _enderecoService;
        private readonly IEstadoService _estadoService;
        private readonly IFuncionarioService _funcionarioService;

        public InicioService(IBairroService bairroService, ICidadeService cidadeService, IEnderecoService enderecoService, IEstadoService estadoService, IFuncionarioService funcionarioService, ICargoService cargoService)
        {
            _bairroService = bairroService;
            _cidadeService = cidadeService;
            _enderecoService = enderecoService;
            _estadoService = estadoService;
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
        }

        public async Task<Response> Iniciar()
        {
            if (!_funcionarioService.Iniciar().Result.Item)
            {
                if (!_enderecoService.Iniciar().Result.Item)
                {
                    if (!_bairroService.Iniciar().Result.Item)
                    {
                        if (!_cidadeService.Iniciar().Result.Item)
                        {
                            if (!_estadoService.Iniciar().Result.Item)
                            {
                                if (!_cargoService.Iniciar().Result.Item)
                                {
                                    _funcionarioService.Insert(
                                    new Funcionario()
                                    {
                                        Nome = "ADM",
                                        Email = "admin@admin.com",
                                        Cpf = "",
                                        Senha = "5457ed4c6b8c29269cc61916d001ab86fb65754b0278e6a2f184a4f9c5887991",
                                        CargoID = _cargoService.IniciarReturnId().Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(
                                            new Endereco()
                                            {
                                                NumeroCasa = "",
                                                Rua = "",
                                                CEP = "",
                                                Complemento = "",
                                                BairroID = _bairroService.InsertReturnId(
                                                    new Bairro()
                                                    {
                                                        NomeBairro = "",
                                                        CidadeId = _cidadeService.InsertReturnId(
                                                            new Cidade
                                                            {
                                                                NomeCidade = "",
                                                                EstadoId = _estadoService.InsertReturnId(new Estado() { Sigla = "", NomeEstado = "" }).Result.Item
                                                            }).Result.Item
                                                    }).Result.Item
                                            }).Result.Item
                                    }); ;
                                }
                                else
                                {
                                    _funcionarioService.Insert(
                                    new Funcionario()
                                    {
                                        Nome = "ADM",
                                        Email = "admin@admin.com",
                                        Cpf = "",
                                        Senha = "5457ed4c6b8c29269cc61916d001ab86fb65754b0278e6a2f184a4f9c5887991",
                                        CargoID = _cargoService.InsertReturnId(new Cargo() { Funcao = "ADMIN", NivelPermissao = 0 }).Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(
                                            new Endereco()
                                            {
                                                NumeroCasa = "",
                                                Rua = "",
                                                CEP = "",
                                                Complemento = "",
                                                BairroID = _bairroService.InsertReturnId(
                                                    new Bairro()
                                                    {
                                                        NomeBairro = "",
                                                        CidadeId = _cidadeService.InsertReturnId(
                                                            new Cidade
                                                            {
                                                                NomeCidade = "",
                                                                EstadoId = _estadoService.InsertReturnId(new Estado() { Sigla = "", NomeEstado = "" }).Result.Item
                                                            }).Result.Item
                                                    }).Result.Item
                                            }).Result.Item
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return new Response();
        }
    }
}