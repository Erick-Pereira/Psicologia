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

        public Task<Response> Delete(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Endereco>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Endereco>> GetByID(int id)
        {
            throw new NotImplementedException();
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

        public Task<Response> Insert(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}