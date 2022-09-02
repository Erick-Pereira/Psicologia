using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICargoDAL
    {
        Task<DataResponse<Cargo>> GetAll();

        Task<Response> Delete(Cargo cargo);

        Task<Response> Insert(Cargo cargo);

        Task<Response> Update(Cargo cargo);

        Task<SingleResponse<Cargo>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);
    }
}