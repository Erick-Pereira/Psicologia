using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Interfaces
{
    public interface ICidadeDAL
    {
        Task<Response> Insert(Cidade cidade);

        Task<Response> Update(Cidade cidade );

        Task<Response> Delete(Cidade cidade);

        Task<SingleResponse<Cidade >> GetByID(int id);

        Task<DataResponse<Cidade>> GetAll();

        Task<SingleResponse<int>> Iniciar();
    }
}
