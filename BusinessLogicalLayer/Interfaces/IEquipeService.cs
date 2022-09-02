using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEquipeService
    {
        Task<DataResponse<Equipe>> GetAll();

        Task<Response> Delete(Equipe equipe);

        Task<Response> Insert(Equipe equipe);

        Task<Response> Update(Equipe equipe);

        Task<SingleResponse<Equipe>> GetByID(int id);
    }
}