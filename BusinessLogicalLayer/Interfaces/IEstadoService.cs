using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEstadoService
    {
        Task<DataResponse<Estado>> GetAll();

        Task<Response> Delete(Estado estado);

        Task<Response> Insert(Estado estado);

        Task<Response> Update(Estado estado);

        Task<SingleResponse<Estado>> GetByID(int id);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Estado estado);
    }
}