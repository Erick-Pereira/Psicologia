using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Validators.FuncionarioValidator;
using DataAcessLayer;
using Entities;
using Entities.Interfaces;
using Shared;

namespace BusinessLogicalLayer
{
    public class FuncionarioService : IFuncionarioService
    {
        private FuncionarioDAL funcionarioDAL = new FuncionarioDAL();

        public Response Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public DataResponse<Funcionario> GetAll()
        {
            return funcionarioDAL.GetAll();
        }

        public SingleResponse<Funcionario> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public SingleResponse<int> GetByLogin(Funcionario funcionario)
        {
            return funcionarioDAL.GetByLogin(funcionario);
        }

        public Response Insert(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Response Update(Funcionario funcionario)
        {
            UpdateFuncionarioValidator validationRules = new UpdateFuncionarioValidator();

            Response response = validationRules.Validate(funcionario).ToResponse();
            if (!response.HasSuccess)
            {
                return response;
            }
            return funcionarioDAL.Update(funcionario);
        }
    }
}