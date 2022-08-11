using DataAcessLayer.Interfaces;
using DataAcessLayer.Migrations;
using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Impl
{
    public class CargoDAL : ICargoDAL
    {
        private readonly DataBaseDbContext _db;

        public CargoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Delete(Cargo cargo)
        {
            _db.Cargo.Remove(cargo);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateSuccessResponse();
            }
            catch (Exception)
            {
                return ResponseFactory.CreateFailureResponse();
            }
        }

        public async Task<DataResponse<Cargo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(Cargo cargo)
        {
            throw new NotImplementedException();
        }
    }
}
