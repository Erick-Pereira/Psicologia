using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IBairroService
    {
        Task<DataResponse<Bairro>> GetAll();

        Task<Response> Delete(Bairro bairro);

        Task<Response> Insert(Bairro bairro);

        Task<Response> Update(Bairro bairro);

        Task<SingleResponse<Bairro>> GetByID(int id);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);
    }
}