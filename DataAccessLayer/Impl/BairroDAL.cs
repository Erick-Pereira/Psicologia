using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class BairroDAL : IBairroDAL
    {
        private readonly DataBaseDbContext _db;

        /// <summary>
        /// Construtor do BairroDAL
        /// </summary>
        /// <param name="db"></param>
        public BairroDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Recebe um ID de Cidade e conta quantos Bairros estão ligados a ela
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros ligados a uma Cidade</returns>
        public async Task<SingleResponse<int>> CountAllByCidadeId(int id)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Bairro.AsNoTracking().Where(e => e.CidadeId == id).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Bairro e Deleta no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros ligados a uma Cidade</returns>
        public async Task<Response> Delete(Bairro bairro)
        {
            _db.Bairro.Remove(bairro);
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
        /// Recebe um ID e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Bairro.Remove(GetByID(id).Result.Item);
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
        /// Resgata todos os Bairros registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Bairros do Banco</returns>
        public async Task<DataResponse<Bairro>> GetAll()
        {
            try
            {
                return ResponseFactory<Bairro>.CreateSuccessDataResponse(await _db.Bairro.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Bairro>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID e Resgata o Bairro referente ao ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Bairro referente ao ID</returns>
        public async Task<SingleResponse<Bairro>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Bairro>.CreateSuccessItemResponse(await _db.Bairro.AsNoTracking().FirstAsync(b => b.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Bairro>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Bairro contendo um Nome e um ID de Cidade
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro que contenha as mesmas informações passadas</returns>
        public async Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro)
        {
            try
            {
                return ResponseFactory<Bairro>.CreateSuccessItemResponse(await _db.Bairro.AsNoTracking().FirstOrDefaultAsync(b => b.NomeBairro == bairro.NomeBairro && b.CidadeId == bairro.CidadeId));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Bairro>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta quantos Bairros tem o nome
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Bairro.Where(b => b.NomeBairro == "").CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Bairro bairro = await _db.Bairro.FirstAsync(b => b.NomeBairro == "");
                return ResponseFactory<int>.CreateSuccessItemResponse(bairro.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Bairro e Insere no Banco de Dados
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Insert(Bairro bairro)
        {
            _db.Bairro.Add(bairro);
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
        ///
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            _db.Bairro.Add(bairro);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(bairro.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<Response> Update(Bairro bairro)
        {
            _db.Bairro.Update(bairro);
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