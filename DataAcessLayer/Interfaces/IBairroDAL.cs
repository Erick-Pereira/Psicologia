using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IBairroDAL
    {
        Task<Response> Insert(Bairro bairro);

        Task<Response> Update(Bairro bairro);

        Task<Response> Delete(Bairro bairro);

        Task<SingleResponse<Bairro>> GetByID(int id);

        Task<DataResponse<Bairro>> GetAll();

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);
    }
}