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
        /// Recebe um Cargo e Chama o metodo Delete do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(Cargo cargo)
        {
            return await _cargoDAL.Delete(cargo);
        }

        /// <summary>
        /// Recebe um ID e chama o metodo Delete do CargoDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            return await _cargoDAL.Delete(id);
        }

        /// <summary>
        /// Chama o metodo GetAll do CargoDAL
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Cargos registrados no Banco de Dados</returns>
        public async Task<DataResponse<Cargo>> GetAll()
        {
            return await _cargoDAL.GetAll();
        }

        /// <summary>
        /// Recebe um id de Cargo e chama o metodo GetById do CargoDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro referente ao ID informado</returns>
        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            return await _cargoDAL.GetByID(id);
        }

        /// <summary>
        /// Chama o metodo iniciar do CargoDAL e verifica se há pelo menos um Cargo com as informações iniciais
        /// </summary>
        /// <returns>Retorna um SingleResponse informando se há pelo menos um Cargo com nivel de Permissão 0</returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _cargoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// Chama o metodo IniciarReturnId do CargoDAL
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um ID de Cargo</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _cargoDAL.IniciarReturnId();
        }

        /// <summary>
        /// Recebe um cargo e chama o metodo Insert do CargoDAL
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
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