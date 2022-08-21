using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IEnderecoDAL
    {
        Task<Response> Insert(Endereco endereco);

        Task<Response> Update(Endereco endereco);

        Task<Response> Delete(Endereco endereco);

        Task<SingleResponse<Endereco>> GetByID(int id);

        Task<DataResponse<Endereco>> GetAll();

        Task<SingleResponse<int>> Iniciar();
        Task<SingleResponse<int>> InsertReturnId(Endereco endereco);

    }
}