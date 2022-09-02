using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IFuncionarioDAL
    {
        Task<DataResponse<Funcionario>> GetAll();

        Task<Response> Delete(Funcionario funcionario);

        Task<Response> Insert(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetByID(int id);

        Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario);

        Task<DataResponse<Funcionario>> GetAllAtivos();

        Task<SingleResponse<int>> Iniciar();

        Task<SingleResponse<int>> Logar(Funcionario funcionario);
    }
}