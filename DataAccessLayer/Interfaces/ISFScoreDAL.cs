using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ISFScoreDAL
    {
        Task<Response> Insert(SF36Score score);
    }
}