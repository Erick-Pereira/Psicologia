using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IEquipeDAL
    {
        Task<DataResponse<Equipe>> GetAll();

        Task<Response> Delete(Equipe equipe);

        Task<Response> Insert(Equipe equipe);

        Task<Response> Update(Equipe equipe);

        Task<SingleResponse<Equipe>> GetByID(int id);
    }
}