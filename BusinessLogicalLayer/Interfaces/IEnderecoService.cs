using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEnderecoService
    {
        Task<DataResponse<Endereco>> GetAll();

        Task<Response> Delete(Endereco endereco);

        Task<Response> Insert(Endereco endereco);

        Task<Response> Update(Endereco endereco);

        Task<SingleResponse<Endereco>> GetByID(int id);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Endereco endereco);
    }
}