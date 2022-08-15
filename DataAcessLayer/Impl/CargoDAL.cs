using DataAcessLayer.Interfaces;
using DataAcessLayer.Migrations;
using Entities;
using Microsoft.EntityFrameworkCore;
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
            DataResponse<Cargo> dataResponse = new()
            {
                Data = await _db.Cargo.ToListAsync()
            };
            return dataResponse;
        }

        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            SingleResponse<Cargo> singleResponse = new()
            {
                Item = await _db.Cargo.FindAsync(id)
            };
            return singleResponse;
        }

        public async Task<Response> Insert(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
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

        public async Task<Response> Update(Cargo cargo)
        {
            _db.Cargo.Update(cargo);
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
    }
}
