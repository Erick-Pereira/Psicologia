using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IBairroDAL
    {
        /// <summary>
        /// Recebe um ID de Cidade e conta quantos Bairros estão ligados a ela
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros ligados a uma Cidade</returns>
        Task<SingleResponse<int>> CountAllByCidadeId(int id);

        /// <summary>
        /// Recebe um Bairro e Deleta no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros ligados a uma Cidade</returns>
        Task<Response> Delete(Bairro bairro);

        /// <summary>
        /// Recebe um ID e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Resgata todos os Bairros registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Bairros do Banco</returns>
        Task<DataResponse<Bairro>> GetAll();

        /// <summary>
        /// Recebe um ID e Resgata o Bairro referente ao ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Bairro referente ao ID</returns>
        Task<SingleResponse<Bairro>> GetByID(int id);

        /// <summary>
        /// Recebe um Bairro contendo um Nome e um ID de Cidade
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro que contenha as mesmas informações passadas</returns>
        Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro);

        /// <summary>
        /// Conta quantos Bairros tem o nome vazio para o primeiro login
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros com nome vazio</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Busca no Banco de Dados o Bairro com nome vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID do Bairro</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe um Bairro e Insere no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Bairro bairro);

        /// <summary>
        /// Recebe um Bairro e Insere no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Bairro inserido</returns>
        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);

        /// <summary>
        /// Recebe um Bairro e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Reponse informando se teve sucesso</returns>
        Task<Response> Update(Bairro bairro);
    }
}