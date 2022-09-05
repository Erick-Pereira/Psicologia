using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICargoDAL
    {
        Task<Response> Delete(Cargo cargo);

        Task<Response> Delete(int id);

        Task<DataResponse<Cargo>> GetAll();

        Task<SingleResponse<Cargo>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Cargo cargo);

        Task<SingleResponse<int>> InsertReturnId(Cargo cargo);

        Task<Response> Update(Cargo cargo);
    }
}