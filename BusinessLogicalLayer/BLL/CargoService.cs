using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class CargoService : ICargoService
    {
        private readonly ICargoDAL _cargoDAL;

        public CargoService(ICargoDAL cargoDAL)
        {
            _cargoDAL = cargoDAL;
        }

        public async Task<Response> Delete(Cargo cargo)
        {
            return await _cargoDAL.Delete(cargo);
        }

        public async Task<DataResponse<Cargo>> GetAll()
        {
            return await _cargoDAL.GetAll();
        }

        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            return await _cargoDAL.GetByID(id);
        }

        public async Task<Response> Insert(Cargo cargo)
        {
            return await _cargoDAL.Insert(cargo);
        }

        public async Task<Response> Update(Cargo cargo)
        {
            return await _cargoDAL.Update(cargo);
        }
    }
}