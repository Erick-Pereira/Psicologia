using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IEstadoDAL
    {
        Task<Response> Insert(Estado estado);

        Task<Response> Update(Estado estado);

        Task<Response> Delete(Estado estado);

        Task<SingleResponse<Estado>> GetByID(int id);

        Task<DataResponse<Estado>> GetAll();

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> InsertReturnId(Estado estado);
    }
}