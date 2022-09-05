using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ICompromissoDAL
    {
        Task<Response> Delete(Compromisso compromisso);

        Task<Response> Delete(int id);

        Task<DataResponse<Compromisso>> GetAll();

        Task<SingleResponse<Compromisso>> GetByID(int id);

        Task<Response> Insert(Compromisso compromisso);

        Task<Response> Update(Compromisso compromisso);
    }
}