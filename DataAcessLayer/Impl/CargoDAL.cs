using DataAcessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

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
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<DataResponse<Cargo>> GetAll()
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessDataResponse(await _db.Cargo.ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessItemResponse(await _db.Cargo.FindAsync(id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Update(Cargo cargo)
        {
            _db.Cargo.Update(cargo);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }
    }
}