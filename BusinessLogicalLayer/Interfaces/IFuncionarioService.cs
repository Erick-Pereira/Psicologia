﻿using Shared;

namespace Entities.Interfaces
{
    public interface IFuncionarioService
    {
        Task<Response> Insert(Funcionario funcionario);

        Task<Response> Update(Funcionario funcionario);

        Task<Response> Delete(Funcionario funcionario);

        Task<SingleResponse<Funcionario>> GetByID(int id);

        Task<DataResponse<Funcionario>> GetAll();
        Task<bool> Logar(Funcionario funcionario);
    }
}