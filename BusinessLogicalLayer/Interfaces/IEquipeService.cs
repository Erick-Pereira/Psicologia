using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEquipeService
    {
        Task<Response> Insert(Equipe equipe);

        Task<Response> Update(Equipe equipe);

        Task<Response> Delete(Equipe equipe);

        Task<SingleResponse<Equipe>> GetByID(int id);

        Task<DataResponse<Equipe>> GetAll();
    }
}