using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
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

        public async Task<Response> Delete(Estado estado)
        {
            return await _estadoDAL.Delete(estado);
        }

        public async Task<DataResponse<Estado>> GetAll()
        {
            return await _estadoDAL.GetAll();
        }

        public async Task<SingleResponse<Estado>> GetByID(int id)
        {
            return await _estadoDAL.GetByID(id);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _estadoDAL.Iniciar();
            return ResponseFactory<bool>.CreateSuccessItemResponse(response.Item < 1);
        }

        public async Task<Response> Insert(Estado estado)
        {
            return await _estadoDAL.Insert(estado);
        }

        public async Task<SingleResponse<int>> InsertReturnId(Estado estado)
        {
            return await _estadoDAL.InsertReturnId(estado);
        }

        public async Task<Response> Update(Estado estado)
        {
            return await _estadoDAL.Update(estado);
        }
    }
}