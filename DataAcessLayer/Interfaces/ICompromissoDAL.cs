using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface ICompromissoDAL
    {
        Task<Response> Insert(Compromisso compromisso);

        Task<Response> Update(Compromisso compromisso);

        Task<Response> Delete(Compromisso compromisso);

        Task<SingleResponse<Compromisso>> GetByID(int id);

        Task<DataResponse<Compromisso>> GetAll();
    }
}