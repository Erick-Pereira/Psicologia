using Entities;
using Shared;

namespace DataAcessLayer.Interfaces
{
    public interface IFuncionarioDAL
    {
        Task<DataResponse<Funcionario>> GetAll();

        Task<Response> Delete(Funcionario funcionario);

        Task<Response> Insert(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetByID(int id);

        Task<SingleResponse<int>> Logar(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario);

        Task<SingleResponse<int>> Iniciar();
    }
}