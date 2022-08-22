using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface ICidadeDAL
    {
        Task<DataResponse<Cidade>> GetAll();

        Task<Response> Delete(Cidade cidade);

        Task<Response> Insert(Cidade cidade);

        Task<Response> Update(Cidade cidade);

        Task<SingleResponse<Cidade>> GetByID(int id);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<SingleResponse<int>> InsertReturnId(Cidade cidade);
    }
}