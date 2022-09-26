using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class SF36ScoreDAL : ISFScoreDAL
    {
        private readonly DataBaseDbContext _db;

        public SF36ScoreDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        public async Task<DataResponse<SF36Score>> GetAllByFuncionarioId(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessDataResponse(await _db.Score.Where(s => s.FuncionarioID == funcionario.ID).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<DataResponse<SF36Score>> GetAllByFuncionarioId(int id)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessDataResponse(await _db.Score.Where(s => s.FuncionarioID == id).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<SF36Score>> GetByFuncionarioIdAndDate(int id, DateTime data)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessItemResponse(await _db.Score.FirstOrDefaultAsync(s => s.FuncionarioID == id && s.Data == data));
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<SingleResponse<SF36Score>> GetByFuncionarioIdAndDate(Funcionario funcionario, DateTime data)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessItemResponse(await _db.Score.FirstOrDefaultAsync(s => s.FuncionarioID == funcionario.ID && s.Data == data));
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(SF36Score score)
        {
            _db.Score.Add(score);
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