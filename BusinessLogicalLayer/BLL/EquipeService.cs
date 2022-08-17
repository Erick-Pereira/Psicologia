using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeDAL _equipeDAL;

        public EquipeService(IEquipeDAL equipeDAL)
        {
            _equipeDAL = equipeDAL;
        }

        public async Task<Response> Delete(Equipe equipe)
        {
            return await _equipeDAL.Delete(equipe);
        }

        public async Task<DataResponse<Equipe>> GetAll()
        {
            return await _equipeDAL.GetAll();
        }

        public async Task<SingleResponse<Equipe>> GetByID(int id)
        {
            return await _equipeDAL.GetByID(id);
        }

        public async Task<Response> Insert(Equipe equipe)
        { 
            return await _equipeDAL.Insert(equipe);
        }

        public async Task<Response> Update(Equipe equipe)
        {
            return await _equipeDAL.Update(equipe);
        }
    }
}