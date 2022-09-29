using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class EstadoDAL : IEstadoDAL
    {
        private readonly DataBaseDbContext _db;

        public EstadoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Recebe um Estado e Deleta no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe um ID de Estado e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Estado.Remove(GetByID(id).Result.Item);
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
        /// Busca no Banco de Dados todos os Estados Registrados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Estados no Banco de Dados</returns>
        public async Task<DataResponse<Estado>> GetAll()
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessDataResponse(await _db.Estado.Where(e => e.NomeEstado != "").ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Estado>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID e busca no Banco de Dados o Estado referente ao ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado referente ao ID passado</returns>
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

        /// <summary>
        /// Recebe um UF e Busca no Banco de Dados o Estado referente ao UF passado
        /// </summary>
        /// <param name="uf"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado</returns>
        public async Task<SingleResponse<Estado>> GetByUF(string uf)
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessItemResponse(await _db.Estado.FirstOrDefaultAsync(e => e.Sigla == uf));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Estado>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///  Recebe um Estado com UF e Nome preenchidos e Busca no Banco de Dados o Estado referente ao UF e Nome passados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado</returns>
        public async Task<SingleResponse<Estado>> GetByUFAndName(Estado estado)
        {
            try
            {
                return ResponseFactory<Estado>.CreateSuccessItemResponse(await _db.Estado.FirstOrDefaultAsync(e => e.Sigla == estado.Sigla && e.NomeEstado == estado.NomeEstado));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Estado>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta a quantidade de Estados com nome e sigla vazios
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Estados com nome Vazio</returns>
        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Estado.Where(b => b.NomeEstado == "" && b.Sigla == "").CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Verificar se existe um Estado com Nome e sigla vazios e busca o ID
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID do Estado</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Estado estado = await _db.Estado.FirstOrDefaultAsync(e => e.NomeEstado == "" && e.Sigla == "");

                return ResponseFactory<int>.CreateSuccessItemResponse(estado.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Estado e Insere no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe um Estado e Insere no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Estado inserido</returns>
        public async Task<SingleResponse<int>> InsertReturnId(Estado estado)
        {
            _db.Estado.Add(estado);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(estado.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Estado e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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