using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class BairroDAL : IBairroDAL
    {
        private readonly DataBaseDbContext _db;

        public BairroDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
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
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> GetAllByCidadeId(int id)
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
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            _db.Bairro.Remove(new Bairro() { ID = id });
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
        /// <returns></returns>
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
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        ///
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
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
        ///
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
        ///
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
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