using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IBairroService
    {
        Task<Response> Delete(Bairro bairro);

        Task<DataResponse<Bairro>> GetAll();

        Task<SingleResponse<Bairro>> GetByID(int id);

        Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> CountAllByCidadeId(int id);

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Bairro bairro);

        Task<SingleResponse<int>> InsertReturnId(Bairro bairro);

        Task<Response> Update(Bairro bairro);
    }
}