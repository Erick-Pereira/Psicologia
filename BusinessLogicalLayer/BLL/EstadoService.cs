using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EstadoService : IEstadoService
    {
        public Task<Response> Delete(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Estado>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Estado>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<bool>> Iniciar()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Estado estado)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Estado estado)
        {
            throw new NotImplementedException();
        }
    }
}