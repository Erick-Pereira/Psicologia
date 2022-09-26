using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ISFScoreDAL
    {
        Task<Response> Insert(SF36Score score);
        Task<SingleResponse<SF36Score>> GetByFuncionarioIdAndDate(int id, DateTime data);
        Task<SingleResponse<SF36Score>> GetByFuncionarioIdAndDate(Funcionario funcionario, DateTime data);
        Task<DataResponse<SF36Score>> GetAllByFuncionarioId(Funcionario funcionario);
        Task<DataResponse<SF36Score>> GetAllByFuncionarioId(int id);
    }
}