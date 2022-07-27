using BusinessLogicalLayer.Extensions;
using DataAcessLayer;
using Entities;
using Entities.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FuncionarioBLL : IFuncionarioService
    {
        FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
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
