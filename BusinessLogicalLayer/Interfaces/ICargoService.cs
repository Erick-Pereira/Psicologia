using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICargoService
    {
        /// <summary>
        /// Recebe um Cargo e Chama o metodo Delete do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Cargo cargo);

        /// <summary>
        /// Recebe um ID e chama o metodo Delete do CargoDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Chama o metodo GetAll do CargoDAL
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Cargos registrados no Banco de Dados</returns>
        Task<DataResponse<Cargo>> GetAll();

        /// <summary>
        /// Recebe um id de Cargo e chama o metodo GetById do CargoDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro referente ao ID informado</returns>
        Task<SingleResponse<Cargo>> GetByID(int id);

        /// <summary>
        /// Chama o metodo iniciar do CargoDAL e verifica se há pelo menos um Cargo com as informações iniciais
        /// </summary>
        /// <returns>Retorna um SingleResponse informando se há pelo menos um Cargo com nivel de Permissão 0</returns>
        Task<SingleResponse<bool>> Iniciar();

        /// <summary>
        /// Chama o metodo IniciarReturnId do CargoDAL
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um ID de Cargo</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe um cargo e chama o metodo Insert do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Cargo cargo);

        /// <summary>
        /// Recebe um cargo e chama o metodo Insert do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Cargo inserido</returns>
        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);

        /// <summary>
        /// Recebe um Cargo e chama o metodo Update do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Cargo cargo);
    }
}