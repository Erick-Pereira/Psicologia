using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.FuncionarioValidator;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioDAL _funcionarioDAL;

        public FuncionarioService(IFuncionarioDAL funcionarioDAL)
        {
            _funcionarioDAL = funcionarioDAL;
        }

        public async Task<Response> Delete(Funcionario funcionario)
        {
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Delete(funcionario);
        }

        public async Task<DataResponse<Funcionario>> GetAll()
        {
            return await _funcionarioDAL.GetAll();
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            return await _funcionarioDAL.GetByID(id);
        }

        public async Task<SingleResponse<int>> GetByLogin(Funcionario funcionario)
        {
            return await _funcionarioDAL.GetByLogin(funcionario);
        }

        public async Task<bool> Logar(Funcionario funcionario)
        {
            if (GetByLogin(funcionario).Result.Item == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = true;
            InsertFuncionarioValidator validationRules = new InsertFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<Response> Update(Funcionario funcionario)
        {
            /*public Response UpdateFuncionarioComEndereco(FuncionarioComEndereco funcionarioComEndereco)
        {
            Response response = new Response();
            FuncionarioValidator funcionarioValidator = new FuncionarioValidator();
            StringValidator stringValidator = new StringValidator();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(stringValidator.ValidateCEP(funcionarioComEndereco.Endereco.CEP));
            stringBuilder.AppendLine(funcionarioValidator.Validate(funcionarioComEndereco.Funcionario).Message);
            string erros = stringBuilder.ToString().Trim();
            if (string.IsNullOrWhiteSpace(erros))
            {
                //Se ele passou por todas as validações e não tem nada de irregular, ele entra if
                using (TransactionScope scope = new TransactionScope())
                {
                    Cidade cidade = new Cidade();
                    Bairro bairro = new Bairro();
                    FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
                    EnderecoDAL enderecoDAL = new EnderecoDAL();
                    CidadeDAL cidadeDAL = new CidadeDAL();
                    BairroDAL bairroDAL = new BairroDAL();
                    int enderecoIdVelho = funcionarioComEndereco.Funcionario.EnderecoId;
                    DataResponse<Funcionario> dataResponseEnderecos = funcionarioDAL.GetAllByEnderecoId(enderecoIdVelho);
                    if (dataResponseEnderecos.Dados.Count != 1)
                    {
                        //Se a quantidade de Funcionarios no endereços for diferente que 1, ele entra no if
                        SingleResponse<Cidade> responseCidade = cidadeDAL.GetByNameAndEstadoId(funcionarioComEndereco.Cidade);
                        if (responseCidade.HasSuccess && responseCidade.Item != null)
                        {
                            //Se tiver uma cidade com mesmo nome, ele entra no if
                            funcionarioComEndereco.Bairro.CidadeId = responseCidade.Item.ID;
                            SingleResponse<Bairro> responseBairro = bairroDAL.GetByNameAndCidadeId(funcionarioComEndereco.Bairro);
                            if (responseBairro.HasSuccess && responseBairro.Item != null)
                            {
                                //Se tiver um bairro com mesmo nome e cidade, ele entra no if
                                funcionarioComEndereco.Bairro.ID = responseBairro.Item.ID;
                                funcionarioComEndereco.Endereco.BairroID = responseBairro.Item.ID;
                                SingleResponse<Endereco> responseEndereco = enderecoDAL.GetByEndereco(funcionarioComEndereco.Endereco);
                                if (responseEndereco.HasSuccess && responseEndereco.Item != null)
                                {
                                    //Se tiver um Endereço igual, ele entra no if
                                    //e faz o update apenas do funcionario
                                    funcionarioComEndereco.Funcionario.EnderecoId = responseEndereco.Item.ID;
                                    response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
                                }
                                else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                                {
                                    //se ele acessou o banco de dados, mas não achou nenhum Endereço igual, ele entra no if
                                    // e faz o cadastro do Endereço e faz o update do funcionario
                                    response = enderecoDAL.Insert(funcionarioComEndereco.Endereco);
                                    funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                                    response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
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
                                response = bairroDAL.Insert(funcionarioComEndereco.Bairro);
                                funcionarioComEndereco.Endereco.BairroID = funcionarioComEndereco.Bairro.ID;
                                response = enderecoDAL.Insert(funcionarioComEndereco.Endereco);
                                funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                                response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
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
                            response = cidadeDAL.Insert(funcionarioComEndereco.Cidade);
                            funcionarioComEndereco.Bairro.CidadeId = funcionarioComEndereco.Cidade.ID;
                            response = bairroDAL.Insert(funcionarioComEndereco.Bairro);
                            funcionarioComEndereco.Endereco.BairroID = funcionarioComEndereco.Bairro.ID;
                            response = enderecoDAL.Insert(funcionarioComEndereco.Endereco);
                            funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                            response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
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
                        SingleResponse<Cidade> responseCidade = cidadeDAL.GetByNameAndEstadoId(funcionarioComEndereco.Cidade);
                        if (responseCidade.HasSuccess && responseCidade.Item != null)
                        {
                            //Se conseguiu acessar o banco e achou uma cidade, entra no if
                            funcionarioComEndereco.Bairro.CidadeId = responseCidade.Item.ID;
                            SingleResponse<Bairro> responseBairro = bairroDAL.GetByNameAndCidadeId(funcionarioComEndereco.Bairro);
                            if (responseBairro.HasSuccess && responseBairro.Item != null)
                            {
                                //Se conseguiu acessar o banco e achou um bairro, entra no if
                                funcionarioComEndereco.Bairro.ID = responseBairro.Item.ID;
                                funcionarioComEndereco.Endereco.BairroID = responseBairro.Item.ID;
                                SingleResponse<Endereco> responseEndereco = enderecoDAL.GetByEndereco(funcionarioComEndereco.Endereco);
                                if (responseEndereco.HasSuccess && responseEndereco.Item != null)
                                {
                                    //se conseguiu acessar o banco e achou um endereço, faz o update do funcionario
                                    funcionarioComEndereco.Funcionario.EnderecoId = responseEndereco.Item.ID;
                                    response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
                                }
                                else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                                {
                                    //se ele conseguiu acessar o banco, mas não achou um endereço, faz o update do Endereço e do Funcionario
                                    response = enderecoDAL.Update(funcionarioComEndereco.Endereco);
                                    funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                                    response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
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
                                response = bairroDAL.Insert(funcionarioComEndereco.Bairro);
                                funcionarioComEndereco.Endereco.BairroID = funcionarioComEndereco.Bairro.ID;
                                response = enderecoDAL.Update(funcionarioComEndereco.Endereco);
                                funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                                response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
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
                            response = cidadeDAL.Insert(funcionarioComEndereco.Cidade);
                            funcionarioComEndereco.Bairro.CidadeId = funcionarioComEndereco.Cidade.ID;
                            response = bairroDAL.Insert(funcionarioComEndereco.Bairro);
                            funcionarioComEndereco.Endereco.BairroID = funcionarioComEndereco.Bairro.ID;
                            response = enderecoDAL.Update(funcionarioComEndereco.Endereco);
                            funcionarioComEndereco.Funcionario.EnderecoId = funcionarioComEndereco.Endereco.ID;
                            response = funcionarioDAL.Update(funcionarioComEndereco.Funcionario);
                        }
                        else
                        {
                            //se ele não conseguiu acessar o banco de dados, retorna o erro
                            response = responseCidade;
                            return response;
                        }
                        dataResponseEnderecos = funcionarioDAL.GetAllByEnderecoId(enderecoIdVelho);
                        if (dataResponseEnderecos.Dados.Count == 0)
                        {
                            //Se não há mais funcionarios no Endereço antigo, deleta o Endereço
                            Response responseDelete = enderecoDAL.Delete(enderecoIdVelho);
                            if (!responseDelete.HasSuccess)
                            {
                                //Caso não tenha sucesso, retorna um Response informando o erro
                                return responseDelete;
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            //scope.Dispose();
            return response;
        }*/
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> singleResponse = await _funcionarioDAL.Iniciar();
            return ResponseFactory<bool>.CreateSuccessItemResponse(singleResponse.Item > 0);
        }
    }
}