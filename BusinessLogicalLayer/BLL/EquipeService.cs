using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    //ESSA CLASSE NÃO ESTA SENDO USADA NO MOMENTO
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeDAL _equipeDAL;

        public EquipeService(IEquipeDAL equipeDAL)
        {
            _equipeDAL = equipeDAL;
        }

        /// <summary>
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Equipe equipe)
        {
            return await _equipeDAL.Delete(equipe);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            return await _equipeDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Equipe>> GetAll()
        {
            return await _equipeDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Equipe>> GetByID(int id)
        {
            return await _equipeDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Equipe equipe)
        {
            return await _equipeDAL.Insert(equipe);
        }

        /// <summary>
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        public async Task<Response> Update(Equipe equipe)
        {
            return await _equipeDAL.Update(equipe);
        }
    }
}