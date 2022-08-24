using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;
using System;

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
        private static bool hasVerified;
        private string nome = "ADM";
        private string email = "admin@admin.com";
        private string senha = "123456789".Hash();
        private string funcao = "ADMIN";
        private int nivelPermissao = 0;

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
            if (!hasVerified)
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
                                        _funcionarioService.InsertADM(
                                        new Funcionario()
                                        {

                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.IniciarReturnId().Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(
                                                new Endereco()
                                                {
                                                    BairroID = _bairroService.InsertReturnId(
                                                        new Bairro()
                                                        {
                                                            CidadeId = _cidadeService.InsertReturnId(
                                                                new Cidade
                                                                {
                                                                    EstadoId = _estadoService.InsertReturnId(new Estado()).Result.Item
                                                                }).Result.Item
                                                        }).Result.Item
                                                }).Result.Item
                                        });
                                    }
                                    else
                                    {
                                        _funcionarioService.InsertADM(
                                        new Funcionario()
                                        {

                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.InsertReturnId(new Cargo() { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(
                                                new Endereco()
                                                {
                                                    BairroID = _bairroService.InsertReturnId(
                                                        new Bairro()
                                                        {
                                                            CidadeId = _cidadeService.InsertReturnId(
                                                                new Cidade
                                                                {
                                                                    EstadoId = _estadoService.InsertReturnId(new Estado()).Result.Item
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
                                        _funcionarioService.InsertADM(new Funcionario()

                                        {

                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.InsertReturnId(new Cargo()

                                            { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
                                                        EstadoId = _estadoService.IniciarReturnId().Result.Item
                                                    }).Result.Item
                                                }).Result.Item
                                            }).Result.Item
                                        });
                                    }
                                    else
                                    {
                                        _funcionarioService.InsertADM(new Funcionario()
                                        {

                                            Nome = nome,
                                            Email = email,
                                            Senha = senha,
                                            CargoID = _cargoService.IniciarReturnId().Result.Item,
                                            EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                            {
                                                BairroID = _bairroService.InsertReturnId(new Bairro()
                                                {
                                                    CidadeId = _cidadeService.InsertReturnId(new Cidade()
                                                    {
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
                                    _funcionarioService.InsertADM(new Funcionario()
                                    {

                                        Nome = nome,
                                        Email = email,
                                        Senha = senha,
                                        CargoID = _cargoService.InsertReturnId(new Cargo()

                                        { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                        {
                                            BairroID = _bairroService.InsertReturnId(new Bairro()
                                            {
                                                CidadeId = _cidadeService.IniciarReturnId().Result.Item
                                            }).Result.Item
                                        }).Result.Item
                                    });
                                }
                                else
                                {
                                    _funcionarioService.InsertADM(new Funcionario()

                                    {

                                        Nome = nome,
                                        Email = email,
                                        Senha = senha,
                                        CargoID = _cargoService.IniciarReturnId().Result.Item,
                                        EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                        {
                                            BairroID = _bairroService.InsertReturnId(new Bairro()
                                            {
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
                                _funcionarioService.InsertADM(new Funcionario()

                                {

                                    Nome = nome,
                                    Email = email,
                                    Senha = senha,
                                    CargoID = _cargoService.InsertReturnId(new Cargo()

                                    { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                    EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                    {
                                        BairroID = _bairroService.IniciarReturnId().Result.Item
                                    }).Result.Item
                                });
                            }
                            else
                            {
                                _funcionarioService.InsertADM(new Funcionario()

                                {

                                    Nome = nome,
                                    Email = email,
                                    Senha = senha,
                                    CargoID = _cargoService.IniciarReturnId().Result.Item,
                                    EnderecoID = _enderecoService.InsertReturnId(new Endereco()
                                    {
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
                            _funcionarioService.InsertADM(new Funcionario()
                            {
                                Nome = nome,
                                Email = email,
                                Senha = senha,
                                CargoID = _cargoService.InsertReturnId(new Cargo()

                                { Funcao = funcao, NivelPermissao = nivelPermissao }).Result.Item,
                                EnderecoID = _enderecoService.IniciarReturnId().Result.Item
                            });
                        }
                        else
                        {
                            _funcionarioService.InsertADM(new Funcionario()

                            {
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