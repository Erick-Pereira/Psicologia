using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IEnderecoDAL
    {
        Task<DataResponse<Endereco>> GetAll();
        Task<Response> Delete(Endereco endereco);
        Task<Response> Insert(Endereco endereco);
        Task<Response> Update(Endereco endereco);
        Task<SingleResponse<Endereco>> GetByID(int id);
        Task<SingleResponse<int>> Iniciar();
        Task<SingleResponse<int>> InsertReturnId(Endereco endereco);
    }
}