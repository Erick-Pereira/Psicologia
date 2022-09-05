using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class EstadoDAL : IEstadoDAL
    {
        private readonly DataBaseDbContext _db;

        public EstadoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Delete(Estado estado)
        {
            _db.Estado.Remove(estado);
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
            _db.Estado.Remove(new Estado() { ID = id });
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

        public async Task<DataResponse<Estado>> GetAll()
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessDataResponse(await _db.Estado.Where(e => e.NomeEstado != "").ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Estado>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Estado>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessItemResponse(await _db.Estado.FindAsync(id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Estado>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Estado.Where(b => b.NomeEstado == "" && b.Sigla == "").CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Estado estado = await _db.Estado.FirstOrDefaultAsync(e => e.NomeEstado == "" && e.Sigla == "");
                return ResponseFactory<int>.CreateSuccessItemResponse(estado.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Estado estado)
        {
            _db.Estado.Add(estado);
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

        public async Task<SingleResponse<int>> InsertReturnId(Estado estado)
        {
            _db.Estado.Add(estado);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(estado.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Update(Estado estado)
        {
            _db.Estado.Update(estado);
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