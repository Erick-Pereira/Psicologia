using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class BairroService : IBairroService
    {
        private readonly IBairroDAL _bairroDAL;

        /// <summary>
        /// Construtor do BairroService
        /// </summary>
        /// <param name="bairroDAL"></param>
        public BairroService(IBairroDAL bairroDAL)
        {
            _bairroDAL = bairroDAL;
        }

        /// <summary>
        /// Recebe um Bairro e chama o metodo Delete do BairroDAL
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(Bairro bairro)
        {
            return await _bairroDAL.Delete(bairro);
        }

        /// <summary>
        /// Chama o Metodo GetAll do BairroDAL
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Bairros do banco de dados</returns>
        public async Task<DataResponse<Bairro>> GetAll()
        {
            return await _bairroDAL.GetAll();
        }

        /// <summary>
        /// Recebe um ID de cidade e pega a quantidade de Bairros ligados a essa cidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> CountAllByCidadeId(int id)
        {
            return await _bairroDAL.CountAllByCidadeId(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Bairro>> GetByID(int id)
        {
            return await _bairroDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro)
        {
            return await _bairroDAL.GetByNameAndCidadeId(bairro);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _bairroDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _bairroDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Bairro bairro)
        {
            return await _bairroDAL.Insert(bairro);
        }

        /// <summary>
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            return await _bairroDAL.InsertReturnId(bairro);
        }

        /// <summary>
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns></returns>
        public async Task<Response> Update(Bairro bairro)
        {
            return await _bairroDAL.Update(bairro);
        }
    }
}