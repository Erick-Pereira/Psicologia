using DataAcessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAcessLayer.Impl
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        private readonly DataBaseDbContext _db;

        public FuncionarioDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        public async Task<Response> Delete(Funcionario funcionario)
        {
            _db.Funcionario.Remove(funcionario);
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

        public async Task<DataResponse<Funcionario>> GetAll()
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(await _db.Funcionario.ToListAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.FindAsync(id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            _db.Funcionario.Add(funcionario);
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

        public async Task<Response> Update(Funcionario funcionario)
        {
            _db.Funcionario.Update(funcionario);
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

        public async Task<SingleResponse<int>> GetByLogin(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.Where(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }
    }
}