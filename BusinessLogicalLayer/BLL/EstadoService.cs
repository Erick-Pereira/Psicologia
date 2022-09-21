using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoDAL _estadoDAL;

        public EstadoService(IEstadoDAL estadoDAL)
        {
            _estadoDAL = estadoDAL;
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Estado estado)
        {
            return await _estadoDAL.Delete(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> Delete(int id)
        {
            return _estadoDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Estado>> GetAll()
        {
            return await _estadoDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Estado>> GetByID(int id)
        {
            return await _estadoDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Estado>> GetByUF(string uf)
        {
            return await _estadoDAL.GetByUF(uf);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _estadoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _estadoDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Estado estado)
        {
            return await _estadoDAL.Insert(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Estado estado)
        {
            return await _estadoDAL.InsertReturnId(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Update(Estado estado)
        {
            return await _estadoDAL.Update(estado);
        }
    }
}