using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ISFScoreDAL
    {
        /// <summary>
        /// Recebe um SF36 e Deleta no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(SF36Score score);

        /// <summary>
        /// Recebe um Funcionario e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario);

        /// <summary>
        /// Recebe um ID de Funcionario e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        Task<DataResponse<SF36Score>> GetAllByFuncionario(int id);

        /// <summary>
        /// Recebe um ID de Funcionario e uma data e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data);

        /// <summary>
        /// Recebe um Funcionario e uma data e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario, DateTime data);

        /// <summary>
        /// Recebe um ID de Funcionario e busca os ultimos 3 SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo os ultimos 3 SF36 ligados ao Funcionario informado</returns>
        Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id);

        /// <summary>
        /// Recebe um SF36 e insere no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(SF36Score score);

        /// <summary>
        /// Recebe um SF36 e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(SF36Score score);
    }
}