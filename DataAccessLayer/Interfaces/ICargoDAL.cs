using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICargoDAL
    {
        /// <summary>
        /// Recebe um Cargo e Deleta no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Cargo cargo);

        /// <summary>
        /// Recebe um ID de Cargo e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Busca todos os Cargos registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Cargos registrados no Banco de Dados</returns>
        Task<DataResponse<Cargo>> GetAll();

        /// <summary>
        /// Recebe um ID de Cargo e Busca um Cargo referente ao ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro referente ao ID informado</returns>
        Task<SingleResponse<Cargo>> GetByID(int id);

        /// <summary>
        /// Conta quantos Cargos tem nivel de Permissão 0
        /// </summary>
        /// <returns>Retorna um SingleResponse informando a quantidade de cargos com nivel de Permissão 0</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Buscar um Cargo com nivel de permissão 0 e retorna o ID dele
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um ID de Cargo</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe um Cargo e insere no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Cargo cargo);

        /// <summary>
        /// Recebe um Cargo e insere no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Cargo inserido</returns>
        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);

        /// <summary>
        /// Recebe um Cargo e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Cargo cargo);
    }
}