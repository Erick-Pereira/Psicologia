using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class CargoService : ICargoService
    {
        private readonly ICargoDAL _cargoDAL;

        //Construtor
        public CargoService(ICargoDAL cargoDAL)
        {
            _cargoDAL = cargoDAL;
        }

        /// <summary>
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Cargo cargo)
        {
            return await _cargoDAL.Delete(cargo);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            return await _cargoDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Cargo>> GetAll()
        {
            return await _cargoDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            return await _cargoDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _cargoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _cargoDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Cargo cargo)
        {
            return await _cargoDAL.Insert(cargo);
        }

        /// <summary>
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Cargo cargo)
        {
            return await _cargoDAL.InsertReturnId(cargo);
        }

        /// <summary>
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Update(Cargo cargo)
        {
            return await _cargoDAL.Update(cargo);
        }
    }
}