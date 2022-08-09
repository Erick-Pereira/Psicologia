using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.FuncionarioValidator;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioDAL _funcionarioDAL;

        public FuncionarioService(IFuncionarioDAL ifuncionarioDAL)
        {
            _funcionarioDAL = ifuncionarioDAL;
        }

        public async Task<Response> Delete(Funcionario funcionario)
        {
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Delete(funcionario);
        }

        public async Task<DataResponse<Funcionario>> GetAll()
        {
            return await _funcionarioDAL.GetAll();
        }

        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            return await _funcionarioDAL.GetByID(id);
        }

        public async Task<SingleResponse<int>> GetByLogin(Funcionario funcionario)
        {
            return await _funcionarioDAL.GetByLogin(funcionario);
        }

        public async Task<bool> Logar(Funcionario funcionario)
        {
            if (GetByLogin(funcionario).Result.Item == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<Response> Update(Funcionario funcionario)
        {
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Update(funcionario);
        }
    }
}