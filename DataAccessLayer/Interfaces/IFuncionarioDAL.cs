using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IFuncionarioDAL
    {
        Task<Response> Delete(Funcionario funcionario);

        Task<Response> Delete(int id);

        Task<DataResponse<Funcionario>> GetAll();

        Task<DataResponse<Funcionario>> GetAllAtivos();

        Task<SingleResponse<int>> CountAllByEnderecoId(int id);

        Task<SingleResponse<Funcionario>> GetByID(int id);

        Task<SingleResponse<Funcionario>> GetInformationToVerify(int id);

        Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario);

        Task<SingleResponse<int>> Iniciar();

        Task<Response> Insert(Funcionario funcionario);

        Task<SingleResponse<int>> Logar(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<DataResponse<Funcionario>> SearchItem(string searchString);
    }
}