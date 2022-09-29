using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;
using Shared.Extensions;

namespace BusinessLogicalLayer.BLL
{
    public class InicioService : IInicioService
    {
        private static bool hasVerified;
        private readonly IBairroService _bairroService;
        private readonly ICargoService _cargoService;
        private readonly ICidadeService _cidadeService;
        private readonly IEnderecoService _enderecoService;
        private readonly IEstadoService _estadoService;
        private readonly IFuncionarioService _funcionarioService;
        private string bairro = "";
        private string cep = "";
        private string cidade = "";
        private string cpf = "";
        private string email = "admin@admin.com";
        private string estado = "";
        private string funcao = "ADMIN";
        private int nivelPermissao = 0;
        private string nome = "ADM";
        private string numCasa = "";
        private string rua = "";
        private string senha = "123456789".Hash();
        private string sigla = "";

        //Construtor
        public InicioService(IBairroService bairroService, ICidadeService cidadeService, IEnderecoService enderecoService, IEstadoService estadoService, IFuncionarioService funcionarioService, ICargoService cargoService)
        {
            _bairroService = bairroService;
            _cidadeService = cidadeService;
            _enderecoService = enderecoService;
            _estadoService = estadoService;
            _funcionarioService = funcionarioService;
            _cargoService = cargoService;
        }

        /// <summary>
        ///  Executa toda a politica para que tenha ao menos um Adm registrado no Banco de Dados
        /// </summary>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Iniciar()

        {
            if (!hasVerified)
            {
                Response response = await _estadoService.VerifyEstados();
                if (!response.HasSuccess)
                {
                    return response;
                }
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
                                        await _funcionarioService.InsertADM(new Funcionario()
                                        {
                                            Cpf = cpf,
                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.InsertReturnId(new Cargo()
                                            {
                                                Funcao = funcao,
                                                NivelPermissao = nivelPermissao
                                            }).Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                NumeroCasa = numCasa,
                                                CEP = cep,
                                                Rua = rua,
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    NomeBairro = bairro,
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
                                                        NomeCidade = cidade,
                                                        EstadoId = _estadoService.InsertReturnId(new Estado()
                                                        {
                                                            NomeEstado = estado,
                                                            Sigla = sigla
                                                        }).Result.Item
                                                    }).Result.Item
                                                }).Result.Item
                                            }).Result.Item
                                        });
                                    }
                                    else
                                    {
                                        await _funcionarioService.InsertADM(new Funcionario()
                                        {
                                            Cpf = cpf,
                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.IniciarReturnId().Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                NumeroCasa = numCasa,
                                                CEP = cep,
                                                Rua = rua,
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    NomeBairro = bairro,
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
                                                        NomeCidade = cidade,
                                                        EstadoId = _estadoService.InsertReturnId(new Estado()
                                                        {
                                                            NomeEstado = estado,
                                                            Sigla = sigla
                                                        }).Result.Item
                                                    }).Result.Item
                                                }).Result.Item
                                            }).Result.Item
                                        });
                                    }
                                }
                                else
                                {
                                    if (!_cargoService.Iniciar().Result.Item)
                                    {
                                        await _funcionarioService.InsertADM(new Funcionario()
                                        {
                                            Cpf = cpf,
                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.InsertReturnId(new Cargo()
                                            {
                                                Funcao = funcao,
                                                NivelPermissao = nivelPermissao
                                            }).Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                NumeroCasa = numCasa,
                                                CEP = cep,
                                                Rua = rua,
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    NomeBairro = bairro,
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
                                                        NomeCidade = cidade,
                                                        EstadoId = _estadoService.IniciarReturnId().Result.Item
                                                    }).Result.Item
                                                }).Result.Item
                                            }).Result.Item
                                        });
                                    }
                                    else
                                    {
                                        await _funcionarioService.InsertADM(new Funcionario()
                                        {
                                            Cpf = cpf,
                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.IniciarReturnId().Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                NumeroCasa = numCasa,
                                                CEP = cep,
                                                Rua = rua,
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    NomeBairro = bairro,
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
                                                        NomeCidade = cidade,
                                                        EstadoId = _estadoService.IniciarReturnId().Result.Item
                                                    }).Result.Item
                                                }).Result.Item
                                            }).Result.Item
                                        });
                                    }
                                }
                            }
                            else
                            {
                                if (!_cargoService.Iniciar().Result.Item)
                                {
                                    await _funcionarioService.InsertADM(new Funcionario()
                                    {
                                        Cpf = cpf,
                                        Nome = nome,
                                        Email = email,
                                        Senha = senha,
                                        CargoID = _cargoService.InsertReturnId(new Cargo()
                                        {
                                            Funcao = funcao,
                                            NivelPermissao = nivelPermissao
                                        }).Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                        {
                                            NumeroCasa = numCasa,
                                            CEP = cep,
                                            Rua = rua,
                                            BairroID = _bairroService.InsertReturnId(new Bairro()
                                            {
                                                NomeBairro = bairro,
                                                CidadeId = _cidadeService.IniciarReturnId().Result.Item
                                            }).Result.Item
                                        }).Result.Item
                                    });
                                }
                                else
                                {
                                    await _funcionarioService.InsertADM(new Funcionario()
                                    {
                                        Cpf = cpf,
                                        Nome = nome,
                                        Email = email,
                                        Senha = senha,
                                        CargoID = _cargoService.IniciarReturnId().Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                        {
                                            NumeroCasa = numCasa,
                                            CEP = cep,
                                            Rua = rua,
                                            BairroID = _bairroService.InsertReturnId(new Bairro()
                                            {
                                                NomeBairro = bairro,
                                                CidadeId = _cidadeService.IniciarReturnId().Result.Item
                                            }).Result.Item
                                        }).Result.Item
                                    });
                                }
                            }
                        }
                        else
                        {
                            if (!_cargoService.Iniciar().Result.Item)
                            {
                                await _funcionarioService.InsertADM(new Funcionario()
                                {
                                    Cpf = cpf,
                                    Nome = nome,
                                    Email = email,
                                    Senha = senha,
                                    CargoID = _cargoService.InsertReturnId(new Cargo()
                                    { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                    EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                    {
                                        NumeroCasa = numCasa,
                                        CEP = cep,
                                        Rua = rua,
                                        BairroID = _bairroService.IniciarReturnId().Result.Item
                                    }).Result.Item
                                });
                            }
                            else
                            {
                                await _funcionarioService.InsertADM(new Funcionario()
                                {
                                    Cpf = cpf,
                                    Nome = nome,
                                    Email = email,
                                    Senha = senha,
                                    CargoID = _cargoService.IniciarReturnId().Result.Item,
                                    EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                    {
                                        NumeroCasa = numCasa,
                                        CEP = cep,
                                        Rua = rua,
                                        BairroID = _bairroService.IniciarReturnId().Result.Item
                                    }).Result.Item
                                });
                            }
                        }
                    }
                    else
                    {
                        if (!_cargoService.Iniciar().Result.Item)
                        {
                            await _funcionarioService.InsertADM(new Funcionario()
                            {
                                Cpf = cpf,
                                Nome = nome,
                                Email = email,
                                Senha = senha,
                                CargoID = _cargoService.InsertReturnId(
                                    new Cargo()
                                    {
                                        Funcao = funcao,
                                        NivelPermissao = nivelPermissao
                                    }).Result.Item,
                                EnderecoID = _enderecoService.IniciarReturnId().Result.Item
                            });
                        }
                        else
                        {
                            await _funcionarioService.InsertADM(new Funcionario()
                            {
                                Cpf = cpf,
                                Nome = nome,
                                Email = email,
                                Senha = senha,
                                CargoID = _cargoService.IniciarReturnId().Result.Item,
                                EnderecoID = _enderecoService.IniciarReturnId().Result.Item
                            });
                        }
                    }
                }
                hasVerified = true;
            }
            return new Response();
        }
    }
}