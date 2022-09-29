using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    //ESSA CLASSE NÃO ESTA SENDO USADA NO MOMENTO
    public interface IEquipeDAL
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        Task<Response> Delete(Equipe equipe);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> Delete(int id);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<DataResponse<Equipe>> GetAll();

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SingleResponse<Equipe>> GetByID(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        Task<Response> Insert(Equipe equipe);

        /// <summary>
        ///
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        Task<Response> Update(Equipe equipe);
    }
}