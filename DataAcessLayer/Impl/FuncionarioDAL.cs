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
                return ResponseFactory.CreateSuccessResponse();
            }
            catch (Exception)
            {
                return ResponseFactory.CreateFailureResponse();
            }
        }

        public async Task<DataResponse<Funcionario>> GetAll()
        {
            DataResponse<Funcionario> dataResponse = new()
            {
                Data = await _db.Funcionario.ToListAsync()
            };
            return dataResponse;
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            SingleResponse<Funcionario> singleResponse = new()
            {
                Item = await _db.Funcionario.FindAsync(id)
            };
            return singleResponse;
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            _db.Funcionario.Add(funcionario);
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

        public async Task<Response> Update(Funcionario funcionario)
        {
            _db.Funcionario.Update(funcionario);
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

        public async Task<SingleResponse<int>> GetByLogin(Funcionario funcionario)
        {
            try
            {
                SingleResponse<int> singleResponse = new()
                {
                    Item = await _db.Funcionario.Where(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha).CountAsync()
                };
                return singleResponse;
            }
            catch (Exception)
            {
                return new SingleResponse<int>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o adm"
                };
            }
        }
    }
}