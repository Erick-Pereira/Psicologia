using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.FuncionarioValidator;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;
using Shared.Extensions;

namespace BusinessLogicalLayer.BLL
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IBairroService _bairroService;
        private readonly ICidadeService _cidadeService;
        private readonly IEnderecoService _enderecoService;
        private readonly IFuncionarioDAL _funcionarioDAL;

        public FuncionarioService(IFuncionarioDAL funcionarioDAL, ICidadeService cidadeService, IBairroService bairroService, IEnderecoService enderecoService)
        {
            _funcionarioDAL = funcionarioDAL;
            _cidadeService = cidadeService;
            _bairroService = bairroService;
            _enderecoService = enderecoService;
        }

        public async Task<Response> Ativar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsAtivo = true;
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<Response> Delete(Funcionario funcionario)
        {
            return await _funcionarioDAL.Delete(funcionario);
        }

        public async Task<Response> Delete(int id)
        {
            return await _funcionarioDAL.Delete(id);
        }

        public async Task<Response> Desativar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsAtivo = false;
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<DataResponse<Funcionario>> GetAll()
        {
            return await _funcionarioDAL.GetAll();
        }

        public async Task<DataResponse<Funcionario>> GetAllAtivos()
        {
            return await _funcionarioDAL.GetAllAtivos();
        }

        public async Task<SingleResponse<int>> GetAllByEnderecoId(int id)
        {
            return await _funcionarioDAL.GetAllByEnderecoId(id);
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            return await _funcionarioDAL.GetByID(id);
        }

        public async Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario)
        {
            return await _funcionarioDAL.GetByLogin(funcionario);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _funcionarioDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = true;
            InsertFuncionarioValidator validationRules = new InsertFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            funcionario.EnderecoID = _enderecoService.IniciarReturnId().Result.Item;
            funcionario.DataNascimento = DateTime.Now;
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<Response> InsertADM(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = true;
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<bool> Logar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            SingleResponse<int> response = await _funcionarioDAL.Logar(funcionario);
            return response.Item == 1;
        }

        public async Task<Response> RequistarUpdate(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = true;
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<Response> ResetarSenha(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<Response> Update(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = false;
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<Response> UpdateAdm(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = false;
            UpdateAdmFuncionarioValidator validationRules = new UpdateAdmFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            Funcionario funcionario2 = _funcionarioDAL.GetByID(funcionario.ID).Result.Item;
            funcionario2.Nome = funcionario.Nome;
            funcionario2.Cpf = funcionario.Cpf;
            funcionario2.Email = funcionario.Email;
            funcionario2.CargoID = funcionario.CargoID;
            funcionario2.Salario = funcionario.Salario;
            return await _funcionarioDAL.Update(funcionario2);
        }

        public async Task<Response> UpdateFuncionario(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = false;
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }

            int enderecoIdVelho = funcionario.EnderecoID;
            if (_funcionarioDAL.GetAllByEnderecoId(funcionario.EnderecoID).Result.Item != 1)
            {
                //Se a quantidade de Funcionarios no endereços for diferente que 1, ele entra no if
                SingleResponse<Cidade> responseCidade = _cidadeService.GetByNameAndEstadoId(funcionario.Endereco.Bairro.Cidade).Result;
                if (responseCidade.HasSuccess && responseCidade.Item != null)
                {
                    //Se tiver uma cidade com mesmo nome, ele entra no if
                    funcionario.Endereco.Bairro.CidadeId = responseCidade.Item.ID;
                    funcionario.Endereco.Bairro.Cidade = responseCidade.Item;
                    SingleResponse<Bairro> responseBairro = _bairroService.GetByNameAndCidadeId(funcionario.Endereco.Bairro).Result;
                    if (responseBairro.HasSuccess && responseBairro.Item != null)
                    {
                        //Se tiver um bairro com mesmo nome e cidade, ele entra no if
                        funcionario.Endereco.Bairro = responseBairro.Item;
                        funcionario.Endereco.BairroID = responseBairro.Item.ID;
                        SingleResponse<Endereco> responseEndereco = _enderecoService.GetByEndereco(funcionario.Endereco).Result;
                        if (responseEndereco.HasSuccess && responseEndereco.Item != null)
                        {
                            //Se tiver um Endereço igual, ele entra no if
                            //e faz o update apenas do funcionario
                            funcionario.EnderecoID = responseEndereco.Item.ID;
                            funcionario.Endereco = responseEndereco.Item;
                            response = _funcionarioDAL.Update(funcionario).Result;
                        }
                        else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                        {
                            //se ele acessou o banco de dados, mas não achou nenhum Endereço igual, ele entra no if
                            // e faz o cadastro do Endereço e faz o update do funcionario
                            response = _enderecoService.Insert(funcionario.Endereco).Result;
                            response = _funcionarioDAL.Update(funcionario).Result;
                        }
                        else
                        {
                            //se ele não conseguiu acessar o banco de dados, retorna o erro
                            response = responseEndereco;
                            return response;
                        }
                    }
                    else if (responseBairro.HasSuccess && responseBairro.Item == null)
                    {
                        //se ele conseguiu acessar o banco de dados, mas não achou nenhum Bairro igual
                        //Cadastra o bairro e o endereço e faz o update do funcionario
                        response = _bairroService.Insert(funcionario.Endereco.Bairro).Result;
                        response = _enderecoService.Insert(funcionario.Endereco).Result;
                        response = _funcionarioDAL.Update(funcionario).Result;
                    }
                    else
                    {
                        //se ele não conseguiu acessar o banco de dados, retorna o erro
                        response = responseBairro;
                        return response;
                    }
                }
                else if (responseCidade.HasSuccess && responseCidade.Item == null)
                {
                    //Se conseguiu acessar o banco de dados, mas não achou nenhuma cidade igual
                    //cadastra Cidade,Bairro,Endereço e faz o update do funcionario
                    response = _cidadeService.Insert(funcionario.Endereco.Bairro.Cidade).Result;
                    response = _bairroService.Insert(funcionario.Endereco.Bairro).Result;
                    response = _enderecoService.Insert(funcionario.Endereco).Result;
                    response = _funcionarioDAL.Update(funcionario).Result;
                }
                else
                {
                    //se ele não conseguiu acessar o banco de dados, retorna o erro
                    response = responseCidade;
                    return response;
                }
            }
            else
            {
                //Se não tem mais de um Funcionario no endereço, entra no enlse
                SingleResponse<Cidade> responseCidade = _cidadeService.GetByNameAndEstadoId(funcionario.Endereco.Bairro.Cidade).Result;
                if (responseCidade.HasSuccess && responseCidade.Item != null)
                {
                    //Se conseguiu acessar o banco e achou uma cidade, entra no if
                    funcionario.Endereco.Bairro.CidadeId = responseCidade.Item.ID;
                    SingleResponse<Bairro> responseBairro = _bairroService.GetByNameAndCidadeId(funcionario.Endereco.Bairro).Result;
                    if (responseBairro.HasSuccess && responseBairro.Item != null)
                    {
                        //Se conseguiu acessar o banco e achou um bairro, entra no if
                        funcionario.Endereco.Bairro = responseBairro.Item;
                        funcionario.Endereco.BairroID = responseBairro.Item.ID;
                        SingleResponse<Endereco> responseEndereco = _enderecoService.GetByEndereco(funcionario.Endereco).Result;
                        if (responseEndereco.HasSuccess && responseEndereco.Item != null)
                        {
                            //se conseguiu acessar o banco e achou um endereço, faz o update do funcionario
                            funcionario.EnderecoID = responseEndereco.Item.ID;
                            funcionario.Endereco = responseEndereco.Item;
                            response = _funcionarioDAL.Update(funcionario).Result;
                        }
                        else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                        {
                            //se ele conseguiu acessar o banco, mas não achou um endereço, faz o update do Endereço e do Funcionario
                            response = _enderecoService.Update(funcionario.Endereco).Result;
                            response = _funcionarioDAL.Update(funcionario).Result;
                        }
                        else
                        {
                            //se ele não conseguiu acessar o banco de dados, retorna o erro
                            response = responseEndereco;
                            return response;
                        }
                    }
                    else if (responseBairro.HasSuccess && responseBairro.Item == null)
                    {
                        //Se conseguiu entrar no banco, mas não achou um Bairro, faz o insert do Bairro e update do Endereço e Funcionario
                        response = _bairroService.Insert(funcionario.Endereco.Bairro).Result;
                        funcionario.Endereco.BairroID = funcionario.Endereco.Bairro.ID;
                        response = _enderecoService.Update(funcionario.Endereco).Result;
                        funcionario.EnderecoID = funcionario.Endereco.ID;
                        response = _funcionarioDAL.Update(funcionario).Result;
                    }
                    else
                    {
                        //se ele não conseguiu acessar o banco de dados, retorna o erro
                        response = responseBairro;
                        return response;
                    }
                }
                else if (responseCidade.HasSuccess && responseCidade.Item == null)
                {
                    //Se conseguiu acessar o banco de dados, mas não achou uma cidade,
                    //faz o Inset da Cidade e Bairro e faz o Update do Endereço e Funcionario
                    response = _cidadeService.Insert(funcionario.Endereco.Bairro.Cidade).Result;
                    funcionario.Endereco.Bairro.CidadeId = funcionario.Endereco.Bairro.Cidade.ID;
                    response = _bairroService.Insert(funcionario.Endereco.Bairro).Result;
                    funcionario.Endereco.BairroID = funcionario.Endereco.Bairro.ID;
                    response = _enderecoService.Update(funcionario.Endereco).Result;
                    funcionario.EnderecoID = funcionario.Endereco.ID;
                    response = _funcionarioDAL.Update(funcionario).Result;
                }
                else
                {
                    //se ele não conseguiu acessar o banco de dados, retorna o erro
                    response = responseCidade;
                    return response;
                }
                if (_funcionarioDAL.GetAllByEnderecoId(enderecoIdVelho).Result.Item == 0)
                {
                    //Se não há mais funcionarios no Endereço antigo, deleta o Endereço
                    Response responseDelete = _enderecoService.Delete(enderecoIdVelho).Result;
                    if (!responseDelete.HasSuccess)
                    {
                        //Caso não tenha sucesso, retorna um Response informando o erro
                        return responseDelete;
                    }
                }
            }
            //scope.Dispose();
            return response;
        }
    }
}