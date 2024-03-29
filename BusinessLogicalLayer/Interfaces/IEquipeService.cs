﻿using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IEquipeService
    {
        Task<Response> Delete(Equipe equipe);

        Task<Response> Delete(int id);

        Task<DataResponse<Equipe>> GetAll();

        Task<SingleResponse<Equipe>> GetByID(int id);

        Task<Response> Insert(Equipe equipe);

        Task<Response> Update(Equipe equipe);
    }
}