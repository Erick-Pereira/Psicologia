using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IFuncionarioDAL
    {
        /// <summary>
        /// Recebe um ID de Endereco e conta todos os Funcionarios que estão ligados a esse Endereco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios ligados a um Endereco</returns>
        Task<SingleResponse<int>> CountAllByEnderecoId(int id);

        /// <summary>
        /// Recebe um Funcionario e Deleta no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Funcionario funcionario);

        /// <summary>
        /// Recebe um ID e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Busca todos os Funcionarios do Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Funcionarios no Banco de Dados</returns>
        Task<DataResponse<Funcionario>> GetAll();

        /// <summary>
        /// Busca todos os Funcionarios ativos do Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Funcionarios ativos no Banco de Dados</returns>
        Task<DataResponse<Funcionario>> GetAllAtivos();

        /// <summary>
        /// Recebe um ID de Funcionario e Busca todas as informações referentes a esse ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Funcionario referente ao ID</returns>
        Task<SingleResponse<Funcionario>> GetByID(int id);

        /// <summary>
        /// Recebe um Funcionario com Email e Senha preenchidos e busca as informações no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um SingleResponse contendo um Funcionario</returns>
        Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario);

        /// <summary>
        /// Recebe um ID de Funcionario e Busca no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse de Funcionario com apenas algumas informações preenchidas</returns>
        Task<SingleResponse<Funcionario>> GetInformationToVerify(int id);

        /// <summary>
        /// Conta quantos Funcionarios tem nivel de permissão 0
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios com permissão 0</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Recebe um Funcionario e Insere no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Funcionario funcionario);

        /// <summary>
        /// Recebe um Funcionario com Email e Senha preenchidos e conta os funcionarios com essas informações no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios com essa informação</returns>
        Task<SingleResponse<int>> Logar(Funcionario funcionario);

        /// <summary>
        /// Recebe um String e procura no banco de dados Funcionarios que parte do nome contenha essa string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Retorna um DataResponse contendo Funcionarios</returns>
        Task<DataResponse<Funcionario>> SearchItem(string searchString);

        /// <summary>
        /// Recebe um Funcionario e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Funcionario funcionario);
    }
}