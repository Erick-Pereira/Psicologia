using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class CargoDAL : ICargoDAL
    {
        private readonly DataBaseDbContext _db;

        public CargoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Recebe um Cargo e Deleta no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(Cargo cargo)
        {
            _db.Cargo.Remove(cargo);
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
        /// Recebe um ID de Cargo e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Cargo.Remove(GetByID(id).Result.Item);
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
        /// Busca todos os Cargos registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Cargos registrados no Banco de Dados</returns>
        public async Task<DataResponse<Cargo>> GetAll()
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessDataResponse(await _db.Cargo.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Cargo e Busca um Cargo referente ao ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro referente ao ID informado</returns>
        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessItemResponse(await _db.Cargo.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta quantos Cargos tem nivel de Permissão 0
        /// </summary>
        /// <returns>Retorna um SingleResponse informando a quantidade de cargos com nivel de Permissão 0</returns>
        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Cargo.Where(c => c.NivelPermissao == 0).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Buscar um Cargo com nivel de permissão 0 e retorna o ID dele
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um ID de Cargo</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Cargo cargo = await _db.Cargo.FirstOrDefaultAsync(c => c.NivelPermissao == 0);

                return ResponseFactory<int>.CreateSuccessItemResponse(cargo.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Cargo e insere no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Insert(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
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
        /// Recebe um Cargo e insere no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Cargo inserido</returns>
        public async Task<SingleResponse<int>> InsertReturnId(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(cargo.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Cargo e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Update(Cargo cargo)
        {
            _db.Cargo.Update(cargo);
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