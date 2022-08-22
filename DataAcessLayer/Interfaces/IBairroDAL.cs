using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IBairroDAL
    {
        Task<DataResponse<Bairro>> GetAll();

        Task<Response> Delete(Bairro bairro);

        Task<Response> Insert(Bairro bairro);

        Task<Response> Update(Bairro bairro);

        Task<SingleResponse<Bairro>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);
    }
}