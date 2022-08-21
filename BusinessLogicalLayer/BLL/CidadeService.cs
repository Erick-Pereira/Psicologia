using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.BLL
{
    internal class CidadeService : ICidadeService
    {
        public Task<Response> Delete(Cidade cidade)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Cidade>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Cidade>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<bool>> Iniciar()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Cidade cidade)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Cidade cidade)
        {
            throw new NotImplementedException();
        }
    }
}
