using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class InicioService : IInicioService
    {
        private readonly IBairroService _bairroService;
        private readonly ICidadeService _cidadeService;
        private readonly IEnderecoService _enderecoService;
        private readonly IEstadoService _estadoService;
        private readonly IFuncionarioService _funcionarioService;

        public InicioService(IFuncionarioService funcionarioService, IEnderecoService enderecoService, IBairroService bairroService, ICidadeService cidadeService, IEstadoService estadoService)
        {
            _funcionarioService = funcionarioService;
            _enderecoService = enderecoService;
            _bairroService = bairroService;
            _cidadeService = cidadeService;
            _estadoService = estadoService;
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
                                _funcionarioService.Insert(
                                    new Funcionario()
                                    {
                                        Nome = "ADM",
                                        Email = "admin@admin.com",
                                        Cpf = "",
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
            return new Response();
        }
    }
}