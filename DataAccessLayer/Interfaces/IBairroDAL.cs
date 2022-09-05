using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IBairroDAL
    {
        Task<Response> Delete(Bairro bairro);

        Task<Response> Delete(int id);

        Task<DataResponse<Bairro>> GetAll();

        Task<SingleResponse<Bairro>> GetByID(int id);

        Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Bairro bairro);

        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);

        Task<Response> Update(Bairro bairro);
    }
}