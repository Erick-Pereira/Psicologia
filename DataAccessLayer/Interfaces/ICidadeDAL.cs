using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICidadeDAL
    {
        Task<Response> Delete(Cidade cidade);

        Task<Response> Delete(int id);

        Task<DataResponse<Cidade>> GetAll();

        Task<SingleResponse<Cidade>> GetByID(int id);

        Task<SingleResponse<Cidade>> GetByNameAndEstadoId(Cidade cidade);

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> IniciarReturnId();

        Task<Response> Insert(Cidade cidade);

        Task<SingleResponse<int>> InsertReturnId(Cidade cidade);

        Task<Response> Update(Cidade cidade);
    }
}