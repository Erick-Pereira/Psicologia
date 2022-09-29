using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICidadeDAL
    {
        /// <summary>
        /// Recebe uma Cidade e Deleta no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Cidade cidade);

        /// <summary>
        /// Recebe um ID de Cidade e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Buscar todas as Cidades Registradas no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todas as Cidade registradas no Banco de Dados</returns>
        Task<DataResponse<Cidade>> GetAll();

        /// <summary>
        /// Recebe um ID de Cidade e Busca Todas as informações no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo uma Cidade referente ao ID informado</returns>
        Task<SingleResponse<Cidade>> GetByID(int id);

        /// <summary>
        /// Recebe uma Cidade contendo Nome e ID de Estado e Busca todas as informações referente a Cidade no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um SingleResponse contendo uma Cidade</returns>
        Task<SingleResponse<Cidade>> GetByNameAndEstadoId(Cidade cidade);

        /// <summary>
        /// Conta quantas Cidades tem o nome vazio para o primeiro login
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Cidades que contem o nome vazio</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Busca o ID da Cidade com o nome vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID da Cidade com nome vazio</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe uma Cidade e insere no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Cidade cidade);

        /// <summary>
        /// Recebe uma Cidade e insere no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um SingleResponse contendo o ID da Cidade inserida</returns>
        Task<SingleResponse<int>> InsertReturnId(Cidade cidade);

        /// <summary>
        /// Recebe uma Cidade e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Cidade cidade);
    }
}