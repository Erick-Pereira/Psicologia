using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class CidadeDAL : ICidadeDAL
    {
        private readonly DataBaseDbContext _db;

        public CidadeDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Recebe uma Cidade e Deleta no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe um ID de Cidade e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Cidade.Remove(GetByID(id).Result.Item);
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
        /// Buscar todas as Cidades Registradas no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todas as Cidade registradas no Banco de Dados</returns>
        public async Task<DataResponse<Cidade>> GetAll()
        {
            try
            {
                return ResponseFactory<Cidade>.CreateSuccessDataResponse(await _db.Cidade.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cidade>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Cidade e Busca Todas as informações no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo uma Cidade referente ao ID informado</returns>
        public async Task<SingleResponse<Cidade>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Cidade>.CreateSuccessItemResponse(await _db.Cidade.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cidade>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe uma Cidade contendo Nome e ID de Estado e Busca todas as informações referente a Cidade no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um SingleResponse contendo uma Cidade</returns>
        public async Task<SingleResponse<Cidade>> GetByNameAndEstadoId(Cidade cidade)
        {
            try
            {
                return ResponseFactory<Cidade>.CreateSuccessItemResponse(await _db.Cidade.AsNoTracking().FirstOrDefaultAsync(c => c.NomeCidade == cidade.NomeCidade && c.EstadoId == cidade.EstadoId));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cidade>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta quantas Cidades tem o nome vazio para o primeiro login
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Cidades que contem o nome vazio</returns>
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

        /// <summary>
        /// Busca o ID da Cidade com o nome vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID da Cidade com nome vazio</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Cidade cidade = await _db.Cidade.FirstOrDefaultAsync(c => c.NomeCidade == "");

                return ResponseFactory<int>.CreateSuccessItemResponse(cidade.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe uma Cidade e insere no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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

        /// <summary>
        /// Recebe uma Cidade e insere no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um SingleResponse contendo o ID da Cidade inserida</returns>
        public async Task<SingleResponse<int>> InsertReturnId(Cidade cidade)
        {
            _db.Cidade.Add(cidade);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(cidade.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe uma Cidade e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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