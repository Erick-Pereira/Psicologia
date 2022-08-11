using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICargoService
    {
        Task<Response> Insert(Cargo cargo);

        Task<Response> Update(Cargo cargo);

        Task<Response> Delete(Cargo cargo);

        Task<SingleResponse<Cargo >> GetByID(int id);

        Task<DataResponse<Cargo>> GetAll();
    }
}
