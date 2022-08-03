using Shared;

namespace Entities.Interfaces
{
    internal interface IFuncionarioService
    {
        Response Insert(Funcionario funcionario);

        Response Update(Funcionario funcionario);

        Response Delete(Funcionario funcionario);

        SingleResponse<Funcionario> GetByID(int id);

        DataResponse<Funcionario> GetAll();
    }
}