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

        Task<SingleResponse<Cargo>> GetByID(int id);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);
    }
}