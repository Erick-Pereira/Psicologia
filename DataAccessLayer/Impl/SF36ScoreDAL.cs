using DataAccessLayer.Interfaces;
using Entities;
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