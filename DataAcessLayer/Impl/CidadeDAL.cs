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
    public class CidadeDAL : ICidadeDAL
    {
        private readonly DataBaseDbContext _db;

        public CidadeDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        public async Task<Response> Delete(Cidade cidade)
        {
            _db.Cidade.Remove(cidade);
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

        public async Task<DataResponse<Cidade>> GetAll()
        {
            try
            {
                return ResponseFactory<Cidade>.CreateSuccessDataResponse(await _db.Cidade.ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cidade>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Cidade>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Cidade>.CreateSuccessItemResponse(await _db.Cidade.FindAsync(id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cidade>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Cidade.Where(b => b.NomeCidade == "").CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Cidade cidade)
        {
            _db.Cidade.Add(cidade);
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

        public async Task<SingleResponse<int>> InsertReturnId(Cidade cidade)
        {
            _db.Cidade.Add(cidade);
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Update(Cidade cidade)
        {
            _db.Cidade.Update(cidade);
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
