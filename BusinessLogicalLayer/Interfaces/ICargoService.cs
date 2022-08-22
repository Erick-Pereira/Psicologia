using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICargoService
    {
        Task<DataResponse<Cargo>> GetAll();
        Task<Response> Delete(Cargo cargo);
        Task<Response> Insert(Cargo cargo);
        Task<Response> Update(Cargo cargo);
        Task<SingleResponse<bool>> Iniciar();
        Task<SingleResponse<Cargo>> GetByID(int id);
        Task<SingleResponse<int>> InsertReturnId();
        Task<SingleResponse<int>> IniciarReturnId();
    }
}