using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IEstadoDAL
    {
        Task<Response> Delete(Estado estado);

        Task<Response> Delete(int id);

        Task<DataResponse<Estado>> GetAll();

        Task<SingleResponse<Estado>> GetByID(int id);

        Task<SingleResponse<Estado>> GetByUF(string uf);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Estado estado);

        Task<SingleResponse<int>> InsertReturnId(Estado estado);

        Task<Response> Update(Estado estado);
    }
}