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

        public FuncionarioService(IFuncionarioDAL funcionarioDAL)
        {
            _funcionarioDAL = funcionarioDAL;
        }

        public async Task<Response> Delete(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
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

        public async Task<bool> Logar(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            SingleResponse<int> response = await _funcionarioDAL.Logar(funcionario);
            return response.Item == 1;
        }

        public async Task<Response> Insert(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = true;
            InsertFuncionarioValidator validationRules = new InsertFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<Response> Update(Funcionario funcionario)
        {            
            funcionario.Email = funcionario.Email.Trim();
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();
            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return await _funcionarioDAL.Update(funcionario);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _funcionarioDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        public async Task<Response> InsertADM(Funcionario funcionario)
        {
            funcionario.Email = funcionario.Email.Trim();
            funcionario.Senha = "123456789".Hash();
            funcionario.IsAtivo = true;
            funcionario.IsFirstLogin = true;
            return await _funcionarioDAL.Insert(funcionario);
        }

        public async Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario)
        {
            return await _funcionarioDAL.GetByLogin(funcionario);
        }
    }
}