using DataAcessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAcessLayer.Impl
{
    public class CompromissoDAL : ICompromissoDAL
    {
        private readonly DataBaseDbContext _db;

        public CompromissoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Delete(Compromisso compromisso)
        {
            _db.Compromisso.Remove(compromisso);
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

        public async Task<DataResponse<Compromisso>> GetAll()
        {
            try
            {
                DataResponse<Compromisso> dataResponse = new()
                {
                    Data = await _db.Compromisso.ToListAsync()
                };
                return dataResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Compromisso>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Compromisso>> GetByID(int id)
        {
            try
            {
                SingleResponse<Compromisso> singleResponse = new()
                {
                    Item = await _db.Compromisso.FindAsync(id)
                };
                return singleResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Compromisso>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Compromisso compromisso)
        {
            _db.Compromisso.Add(compromisso);
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

        public async Task<Response> Update(Compromisso compromisso)
        {
            _db.Compromisso.Update(compromisso);
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