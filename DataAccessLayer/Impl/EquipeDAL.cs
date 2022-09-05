using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class EquipeDAL : IEquipeDAL
    {
        private readonly DataBaseDbContext _db;

        public EquipeDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        public async Task<Response> Delete(Equipe equipe)
        {
            _db.Equipe.Remove(equipe);
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

        public async Task<Response> Delete(int id)
        {
            _db.Equipe.Remove(new Equipe() { ID = id });
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

        public async Task<DataResponse<Equipe>> GetAll()
        {
            try
            {
                DataResponse<Equipe> dataResponse = new()
                {
                    Data = await _db.Equipe.ToListAsync()
                };
                return dataResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Equipe>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Equipe>> GetByID(int id)
        {
            try
            {
                SingleResponse<Equipe> singleResponse = new()
                {
                    Item = await _db.Equipe.FindAsync(id)
                };
                return singleResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Equipe>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Equipe equipe)
        {
            _db.Equipe.Add(equipe);
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

        public async Task<Response> Update(Equipe equipe)
        {
            _db.Equipe.Update(equipe);
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