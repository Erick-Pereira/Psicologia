using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
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

        public async Task<Response> Delete(int id)
        {
            _db.Funcionario.Remove(new Funcionario() { ID = id });
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
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(await _db.Funcionario.Include(f => f.Cargo).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<DataResponse<Funcionario>> GetAllAtivos()
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(await _db.Funcionario.Where(f => f.IsAtivo == true).Include(f => f.Cargo).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> GetAllByEnderecoId(int id)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.Where(f => f.EnderecoID == id).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.Include(f => f.Cargo).Include(f => f.Endereco).Include(f => f.Endereco.Bairro).Include(f => f.Endereco.Bairro.Cidade).Include(f => f.Endereco.Bairro.Cidade.Estado).FirstOrDefaultAsync(f => f.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.FirstAsync(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.Where(f => f.Cargo.NivelPermissao == 0).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            _db.Funcionario.Add(funcionario);
            try
            {
                _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> Logar(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.Where(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha && f.IsAtivo == true).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<Funcionario>> GetInformationToVerify(int id)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.Include(f => f.Cargo).Select(f => new Funcionario { ID = f.ID, IsFirstLogin = f.IsFirstLogin, HasRequiredTest = f.HasRequiredTest, Cargo = new Cargo { NivelPermissao = f.Cargo.NivelPermissao } }).FirstOrDefaultAsync(f => f.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Update(Funcionario funcionario)
        {
            _db.Update(funcionario);
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