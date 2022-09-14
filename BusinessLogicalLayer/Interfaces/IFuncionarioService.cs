using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IFuncionarioService
    {
        Task<Response> Ativar(Funcionario funcionario);

        Task<Response> Delete(Funcionario funcionario);

        Task<Response> Delete(int id);

        Task<Response> Desativar(Funcionario funcionario);

        Task<DataResponse<Funcionario>> GetAll();

        Task<DataResponse<Funcionario>> GetAllAtivos();

        Task<Response> AlterarSenha(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetByID(int id);

        Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario);

        Task<SingleResponse<bool>> Iniciar();

        Task<Response> Insert(Funcionario funcionario);

        Task<Response> InsertADM(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetInformationToVerify(int id);

        Task<bool> Logar(Funcionario funcionario);

        Task<Response> RequistarUpdate(Funcionario funcionario);

        Task<Response> RequistarTeste(Funcionario funcionario);

        Task<Response> ResetarSenha(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<Response> UpdateAdm(Funcionario funcionario);

        Task<Response> UpdateFuncionario(Funcionario funcionario);
    }
}