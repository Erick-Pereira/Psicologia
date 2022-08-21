using DataAcessLayer.Interfaces;
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

        public async Task<DataResponse<Estado>> GetAll()
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessDataResponse(await _db.Estado.ToListAsync());
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
            throw new NotImplementedException();
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
