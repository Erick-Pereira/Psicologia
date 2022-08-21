using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IFuncionarioService
    {
        Task<bool> Logar(Funcionario funcionario);

        Task<DataResponse<Funcionario>> GetAll();

        Task<Response> Delete(Funcionario funcionario);

        Task<Response> Insert(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<SingleResponse<bool>> Iniciar();

        Task<SingleResponse<Funcionario>> GetByID(int id);
    }
}