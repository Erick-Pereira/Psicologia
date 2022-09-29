using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEstadoService
    {
        Task<Response> Delete(Estado estado);

        Task<Response> Delete(int id);

        Task<DataResponse<Estado>> GetAll();

        Task<SingleResponse<Estado>> GetByID(int id);

        Task<SingleResponse<Estado>> GetByUF(string uf);

        Task<Response> VerifyEstados();

        Task<SingleResponse<Estado>> GetByUFAndName(Estado estado);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Estado estado);

        Task<SingleResponse<int>> InsertReturnId(Estado estado);

        Task<Response> Update(Estado estado);
    }
}