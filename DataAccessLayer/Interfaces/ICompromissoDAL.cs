using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    //ESSA CLASSE NÃO ESTA SENDO USADA NO MOMENTO
    public interface ICompromissoDAL
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        Task<Response> Delete(Compromisso compromisso);

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
        Task<DataResponse<Compromisso>> GetAll();

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SingleResponse<Compromisso>> GetByID(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        Task<Response> Insert(Compromisso compromisso);

        /// <summary>
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        Task<Response> Update(Compromisso compromisso);
    }
}