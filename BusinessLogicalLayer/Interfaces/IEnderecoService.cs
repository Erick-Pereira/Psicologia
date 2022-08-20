using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEnderecoService
    {
        Task<Response> Insert(Endereco endereco);

        Task<Response> Update(Endereco endereco);

        Task<Response> Delete(Endereco endereco);

        Task<SingleResponse<Endereco>> GetByID(int id);

        Task<DataResponse<Endereco>> GetAll();

        Task<SingleResponse<bool>> Iniciar();
    }
}