using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IEstadoDAL
    {
        Task<DataResponse<Estado>> GetAll();

        Task<Response> Delete(Estado estado);

        Task<Response> Insert(Estado estado);

        Task<Response> Update(Estado estado);

        Task<SingleResponse<Estado>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Estado estado);
    }
}