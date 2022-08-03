using Shared;

namespace Entities.Interfaces
{
    public interface IFuncionarioService
    {
        Response Insert(Funcionario funcionario);

        Response Update(Funcionario funcionario);

        Response Delete(Funcionario funcionario);

        SingleResponse<Funcionario> GetByID(int id);

        DataResponse<Funcionario> GetAll();
    }
}