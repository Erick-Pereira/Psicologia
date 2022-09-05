using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICargoService
    {
        Task<Response> Delete(Cargo cargo);

        Task<Response> Delete(int id);

        Task<DataResponse<Cargo>> GetAll();

        Task<SingleResponse<Cargo>> GetByID(int id);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Cargo cargo);

        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);

        Task<Response> Update(Cargo cargo);
    }
}