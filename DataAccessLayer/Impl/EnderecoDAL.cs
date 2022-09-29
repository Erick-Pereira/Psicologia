using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class EnderecoDAL : IEnderecoDAL
    {
        private readonly DataBaseDbContext _db;

        public EnderecoDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Recebe um ID de Bairro e Conta quantos Enderecos estão ligados a esse Bairro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Enderecos ligados a um Bairro</returns>
        public async Task<SingleResponse<int>> CountAllByBairroId(int id)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Endereco.AsNoTracking().Where(e => e.BairroID == id).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Endereco e Deleta no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe um ID de Endereco e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Endereco.Remove(GetByID(id).Result.Item);
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

        /// <summary>
        /// Busca todos os Enderecos registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Enderecos registrados no Banco de Dados</returns>
        public async Task<DataResponse<Endereco>> GetAll()
        {
            try
            {
                return ResponseFactory<Endereco>.CreateSuccessDataResponse(await _db.Endereco.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Endereco>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Endereco contendo rua,numero da casa, CEP e ID de Bairro e Busca no Banco de Dados um Bairro com as mesmas informações
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um SingleResponse contendo um Endereco com as mesmas informações recebidas</returns>

        public async Task<SingleResponse<Endereco>> GetByEndereco(Endereco endereco)

        {
            try
            {
                return ResponseFactory<Endereco>.CreateSuccessItemResponse(_db.Endereco.AsNoTracking().FirstOrDefaultAsync(e => e.Rua == endereco.Rua && e.NumeroCasa == endereco.NumeroCasa && e.CEP == endereco.CEP && e.BairroID == endereco.BairroID).Result);
            }
            catch (Exception ex)
            {
                return ResponseFactory<Endereco>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Endereco e Busca todas as informações referentes ao ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Endereco referente ao ID informado</returns>
        public async Task<SingleResponse<Endereco>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Endereco>.CreateSuccessItemResponse(await _db.Endereco.AsNoTracking().FirstOrDefaultAsync(e => e.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Endereco>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta quantos Enderecos tem valores vazios para o primeiro registro
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Enderecos com valores vazios</returns>
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

        /// <summary>
        /// Busca um Endereco com cep e rua vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um Endereco</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Endereco endereco = await _db.Endereco.FirstOrDefaultAsync(e => e.CEP == "" && e.Rua == "");

                return ResponseFactory<int>.CreateSuccessItemResponse(endereco.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Endereco e Insere no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe um Endereco e Insere no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Endereco inserido</returns>
        public async Task<SingleResponse<int>> InsertReturnId(Endereco endereco)
        {
            _db.Endereco.Add(endereco);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(endereco.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Endereco e faz Update no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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