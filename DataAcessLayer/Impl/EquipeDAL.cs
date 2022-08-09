using DataAcessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAcessLayer.Impl
{
    public class EquipeDAL : IEquipeDAL
    {
        private readonly DataBaseDbContext _db;

        public EquipeDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Delete(Equipe equipe)
        {
            _db.Equipe.Remove(equipe);
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

        public async Task<DataResponse<Equipe>> GetAll()
        {
            DataResponse<Equipe> dataResponse = new()
            {
                Data = await _db.Equipe.ToListAsync()
            };
            return dataResponse;
        }

        public async Task<SingleResponse<Equipe>> GetByID(int id)
        {
            SingleResponse<Equipe> singleResponse = new()
            {
                Item = await _db.Equipe.FindAsync(id)
            };
            return singleResponse;
        }

        public async Task<Response> Insert(Equipe equipe)
        {
            _db.Equipe.Add(equipe);
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

        public async Task<Response> Update(Equipe equipe)
        {
            _db.Equipe.Update(equipe);
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