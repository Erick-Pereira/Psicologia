using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICidadeService
    {
        Task<DataResponse<Cidade>> GetAll();
        Task<Response> Delete(Cidade cidade);
        Task<Response> Insert(Cidade cidade);
        Task<Response> Update(Cidade cidade);
        Task<SingleResponse<bool>> Iniciar();
        Task<SingleResponse<Cidade>> GetByID(int id);
        Task<SingleResponse<int>> InsertReturnId(Cidade cidade);
    }
}