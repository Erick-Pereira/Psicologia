using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IEnderecoDAL
    {
        Task<Response> Delete(Endereco endereco);

        Task<Response> Delete(int id);

        Task<DataResponse<Endereco>> GetAll();

        Task<SingleResponse<Endereco>> GetByEndereco(Endereco endereco);
        Task<SingleResponse<int>> GetAllByBairroId(int id);

        Task<SingleResponse<Endereco>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Endereco endereco);

        Task<SingleResponse<int>> InsertReturnId(Endereco endereco);

        Task<Response> Update(Endereco endereco);
    }
}