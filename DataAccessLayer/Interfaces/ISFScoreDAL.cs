using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface ISFScoreDAL
    {
        Task<Response> Insert(SF36Score score);
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data);
        Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario, DateTime data);
        Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario);
        Task<DataResponse<SF36Score>> GetAllByFuncionario(int id);
        Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id);

        Task<Response> Update(SF36Score score);
        Task<Response> Delete(SF36Score score);
    }
}