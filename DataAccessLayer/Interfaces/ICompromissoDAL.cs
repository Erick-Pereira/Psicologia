using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICompromissoDAL
    {
        Task<DataResponse<Compromisso>> GetAll();

        Task<Response> Delete(Compromisso compromisso);

        Task<Response> Insert(Compromisso compromisso);

        Task<Response> Update(Compromisso compromisso);

        Task<SingleResponse<Compromisso>> GetByID(int id);
    }
}