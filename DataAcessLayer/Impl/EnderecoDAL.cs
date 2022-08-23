using DataAcessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAcessLayer.Impl
{
    public class EnderecoDAL : IEnderecoDAL
    {
        private readonly DataBaseDbContext _db;

        public EnderecoDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        public async Task<Response> Delete(Endereco endereco)
        {
            _db.Endereco.Remove(endereco);
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

        public async Task<DataResponse<Endereco>> GetAll()
        {
            try
            {
                return ResponseFactory<Endereco>.CreateSuccessDataResponse(await _db.Endereco.ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Endereco>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Endereco>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Endereco>.CreateSuccessItemResponse(await _db.Endereco.FindAsync(id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Endereco>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Endereco.Where(e => e.CEP == "" && e.Rua == "" && e.Bairro.NomeBairro == "" && e.Bairro.Cidade.NomeCidade == "" && e.Bairro.Cidade.Estado.NomeEstado == "").CountAsync());
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
                Endereco endereco = await _db.Endereco.FirstAsync(e => e.CEP == "" && e.Rua == "");
                return ResponseFactory<int>.CreateSuccessItemResponse(endereco.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Endereco endereco)
        {
            _db.Endereco.Add(endereco);
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

        public async Task<SingleResponse<int>> InsertReturnId(Endereco endereco)
        {
            _db.Endereco.Add(endereco);
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Update(Endereco endereco)
        {
            _db.Endereco.Update(endereco);
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