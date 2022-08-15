using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICargoService
    {
        Task<Response> Insert(Cargo cargo);

        Task<Response> Update(Cargo cargo);

        Task<Response> Delete(Cargo cargo);

        Task<SingleResponse<Cargo>> GetByID(int id);

        Task<DataResponse<Cargo>> GetAll();
    }
}