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

        //Construtor
        public FuncionarioService(IFuncionarioDAL funcionarioDAL, ICidadeService cidadeService, IBairroService bairroService, IEnderecoService enderecoService)
        {
            _funcionarioDAL = funcionarioDAL;
            _cidadeService = cidadeService;
            _bairroService = bairroService;
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> AlterarSenha(Funcionario funcionario)
        {
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> Ativar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsAtivo = true;
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Funcionario funcionario)
        {
            return await _funcionarioDAL.Delete(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            return await _funcionarioDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> Desativar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsAtivo = false;
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Funcionario>> GetAll()
        {
            return await _funcionarioDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Funcionario>> GetAllAtivos()
        {
            return await _funcionarioDAL.GetAllAtivos();
        }

        public async Task<DataResponse<Funcionario>> SearchItem(string searchString)
        {
            return await _funcionarioDAL.SearchItem(searchString);
        }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SingleResponse<int>> GetAllByEnderecoId(int id)
        {
            return await _funcionarioDAL.GetAllByEnderecoId(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            return await _funcionarioDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario)
        {
            return await _funcionarioDAL.GetByLogin(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Funcionario>> GetInformationToVerify(int id)
        {
            return await _funcionarioDAL.GetInformationToVerify(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _funcionarioDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> InsertADM(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = false;
            funcionario.HasRequiredTest = false;
            return await _funcionarioDAL.Insert(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<bool> Logar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            SingleResponse<int> response = await _funcionarioDAL.Logar(funcionario);
            return response.Item == 1;
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> RequistarTeste(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.HasRequiredTest = true;
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> RequistarUpdate(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = true;
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        public async Task<Response> ResetarSenha(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            return await _funcionarioDAL.Update(funcionario);
        }

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// </summary>
        /// <param name="funcionarioUpdate"></param>
        /// <returns></returns>
        public async Task<Response> UpdateFuncionario(Funcionario funcionarioUpdate)
        {
            Funcionario funcionario = ObjectCloner<Funcionario, Funcionario>.To(funcionarioUpdate);
            funcionario.Email = funcionario.Email.Trim();
            funcionario.IsFirstLogin = false;
            funcionarioUpdate.IsFirstLogin = false;
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }

            int enderecoIdVelho = funcionario.EnderecoID;
            int verify = _funcionarioDAL.GetAllByEnderecoId(funcionario.EnderecoID).Result.Item;
            if (verify != 1)
            {
                //Se a quantidade de Funcionarios no endereços for diferente que 1, ele entra no if
                SingleResponse<Cidade> responseCidade = await _cidadeService.GetByNameAndEstadoId(funcionario.Endereco.Bairro.Cidade);
                if (responseCidade.HasSuccess && responseCidade.Item != null)
                {
                    //Se tiver uma cidade com mesmo nome, ele entra no if
                    funcionario.Endereco.Bairro.CidadeId = responseCidade.Item.ID;
                    funcionario.Endereco.Bairro.Cidade = responseCidade.Item;
                    SingleResponse<Bairro> responseBairro = await _bairroService.GetByNameAndCidadeId(funcionario.Endereco.Bairro);
                    if (responseBairro.HasSuccess && responseBairro.Item != null)
                    {
                        //Se tiver um bairro com mesmo nome e cidade, ele entra no if
                        funcionario.Endereco.BairroID = responseBairro.Item.ID;
                        funcionario.Endereco.Bairro = responseBairro.Item;
                        SingleResponse<Endereco> responseEndereco = await _enderecoService.GetByEndereco(funcionario.Endereco);
                        if (responseEndereco.HasSuccess && responseEndereco.Item != null)
                        {
                            //Se tiver um Endereço igual, ele entra no if
                            //e faz o update apenas do funcionario
                            funcionario.EnderecoID = responseEndereco.Item.ID;
                            funcionario.Endereco = responseEndereco.Item;
                            response = await _funcionarioDAL.Update(funcionario);
                        }
                        else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                        {
                            //se ele acessou o banco de dados, mas não achou nenhum Endereço igual, ele entra no if
                            // e faz o cadastro do Endereço e faz o update do funcionario
                            Endereco copyOfEndereco = ObjectCloner<Endereco, Endereco>.To(funcionario.Endereco);
                            copyOfEndereco.ID = 0;

                            copyOfEndereco.Bairro = null;

                            response = await _enderecoService.Insert(copyOfEndereco);
                            if (!response.HasSuccess)
                            {
                                return response;
                            }
                            funcionario.EnderecoID = copyOfEndereco.ID;

                            funcionario.Endereco = null;

                            response = await _funcionarioDAL.Update(funcionario);
                        }
                        else
                        {
                            //se ele não conseguiu acessar o banco de dados, retorna o erro
                            return responseEndereco;
                        }
                    }
                    else if (responseBairro.HasSuccess && responseBairro.Item == null)
                    {
                        //se ele conseguiu acessar o banco de dados, mas não achou nenhum Bairro igual
                        //Cadastra o bairro e o endereço e faz o update do funcionario
                        Bairro copyOfBairro = ObjectCloner<Bairro, Bairro>.To(funcionario.Endereco.Bairro);
                        Endereco copyOfEndereco = ObjectCloner<Endereco, Endereco>.To(funcionario.Endereco);
                        copyOfBairro.ID = 0;

                        copyOfBairro.Cidade = null;

                        response = await _bairroService.Insert(copyOfBairro);
                        if (!response.HasSuccess)
                        {
                            return response;
                        }
                        copyOfEndereco.BairroID = copyOfBairro.ID;

                        copyOfEndereco.Bairro = null;

                        copyOfEndereco.ID = 0;
                        response = await _enderecoService.Insert(copyOfEndereco);
                        if (!response.HasSuccess)
                        {
                            return response;
                        }
                        funcionario.EnderecoID = copyOfEndereco.ID;

                        funcionario.Endereco = null;

                        response = await _funcionarioDAL.Update(funcionario);
                    }
                    else
                    {
                        //se ele não conseguiu acessar o banco de dados, retorna o erro
                        return responseBairro;
                    }
                }
                else if (responseCidade.HasSuccess && responseCidade.Item == null)
                {
                    //Se conseguiu acessar o banco de dados, mas não achou nenhuma cidade igual
                    //cadastra Cidade,Bairro,Endereço e faz o update do funcionario
                    Cidade copyOfCidade = ObjectCloner<Cidade, Cidade>.To(funcionario.Endereco.Bairro.Cidade);
                    Bairro copyOfBairro = ObjectCloner<Bairro, Bairro>.To(funcionario.Endereco.Bairro);
                    Endereco copyOfEndereco = ObjectCloner<Endereco, Endereco>.To(funcionario.Endereco);
                    copyOfCidade.ID = 0;

                    copyOfCidade.Estado = null;

                    response = await _cidadeService.Insert(copyOfCidade);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    copyOfBairro.CidadeId = copyOfCidade.ID;

                    copyOfBairro.Cidade = null;

                    copyOfBairro.ID = 0;
                    response = await _bairroService.Insert(funcionario.Endereco.Bairro);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    copyOfEndereco.BairroID = copyOfBairro.ID;

                    copyOfEndereco.Bairro = null;

                    copyOfEndereco.ID = 0;
                    response = await _enderecoService.Insert(copyOfEndereco);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    funcionario.EnderecoID = copyOfEndereco.ID;

                    funcionario.Endereco = null;

                    response = await _funcionarioDAL.Update(funcionario);
                }
                else
                {
                    //se ele não conseguiu acessar o banco de dados, retorna o erro
                    return responseCidade;
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
                            response = await _funcionarioDAL.Update(funcionario);
                        }
                        else if (responseEndereco.HasSuccess && responseEndereco.Item == null)
                        {
                            //se ele conseguiu acessar o banco, mas não achou um endereço, faz o update do Endereço e do Funcionario
                            response = await _enderecoService.Update(funcionario.Endereco);
                            if (!response.HasSuccess)
                            {
                                return response;
                            }
                            response = await _funcionarioDAL.Update(funcionario);
                        }
                        else
                        {
                            //se ele não conseguiu acessar o banco de dados, retorna o erro
                            return responseEndereco;
                        }
                    }
                    else if (responseBairro.HasSuccess && responseBairro.Item == null)
                    {
                        //Se conseguiu entrar no banco, mas não achou um Bairro, faz o insert do Bairro e update do Endereço e Funcionario
                        Bairro copyOfBairro = ObjectCloner<Bairro, Bairro>.To(funcionario.Endereco.Bairro);
                        copyOfBairro.ID = 0;

                        copyOfBairro.Cidade = null;

                        response = await _bairroService.Insert(copyOfBairro);
                        if (!response.HasSuccess)
                        {
                            return response;
                        }
                        funcionario.Endereco.BairroID = copyOfBairro.ID;

                        funcionario.Endereco.Bairro = null;

                        response = await _enderecoService.Update(funcionario.Endereco);
                        if (!response.HasSuccess)
                        {
                            return response;
                        }
                        funcionario.EnderecoID = funcionario.Endereco.ID;
                        response = await _funcionarioDAL.Update(funcionario);
                    }
                    else
                    {
                        //se ele não conseguiu acessar o banco de dados, retorna o erro
                        return responseBairro;
                    }
                }
                else if (responseCidade.HasSuccess && responseCidade.Item == null)
                {
                    //Se conseguiu acessar o banco de dados, mas não achou uma cidade,
                    //faz o Inset da Cidade e Bairro e faz o Update do Endereço e Funcionario
                    Cidade copyOfCidade = ObjectCloner<Cidade, Cidade>.To(funcionario.Endereco.Bairro.Cidade);
                    Bairro copyOfBairro = ObjectCloner<Bairro, Bairro>.To(funcionario.Endereco.Bairro);
                    copyOfCidade.ID = 0;

                    copyOfCidade.Estado = null;

                    response = await _cidadeService.Insert(copyOfCidade);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    copyOfBairro.CidadeId = copyOfCidade.ID;

                    copyOfBairro.Cidade = null;

                    copyOfBairro.ID = 0;
                    response = await _bairroService.Insert(copyOfBairro);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    funcionario.Endereco.BairroID = copyOfBairro.ID;

                    funcionario.Endereco.Bairro = null;

                    response = await _enderecoService.Update(funcionario.Endereco);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                    funcionario.EnderecoID = funcionario.Endereco.ID;
                    response = await _funcionarioDAL.Update(funcionario);
                }
                else
                {
                    //se ele não conseguiu acessar o banco de dados, retorna o erro
                    return responseCidade;
                }
            }
            if (_funcionarioDAL.GetAllByEnderecoId(enderecoIdVelho).Result.Item == 0)
            {
                //Se não há mais funcionarios no Endereço antigo, deleta o Endereço
                Endereco endereco = _enderecoService.GetByID(enderecoIdVelho).Result.Item;
                Response responseDelete = await _enderecoService.Delete(enderecoIdVelho);
                if (responseDelete.HasSuccess)
                {
                    Bairro bairro = _bairroService.GetByID(endereco.BairroID).Result.Item;
                    if (_enderecoService.GetAllByBairroId(bairro.ID).Result.Item == 0)
                    {
                        responseDelete = await _bairroService.Delete(bairro);
                        if (responseDelete.HasSuccess)
                        {
                            Cidade cidade = _cidadeService.GetByID(bairro.CidadeId).Result.Item;
                            if (_bairroService.GetAllByCidadeId(cidade.ID).Result.Item == 0)
                            {
                                responseDelete = await _cidadeService.Delete(cidade);
                                if (!responseDelete.HasSuccess)
                                {
                                    return responseDelete;
                                }
                            }
                        }
                        else
                        {
                            return responseDelete;
                        }
                    }
                }
                else
                {
                    //Caso não tenha sucesso, retorna um Response informando o erro
                    return responseDelete;
                }
            }
            //scope.Dispose();
            return response;
        }
    }
}