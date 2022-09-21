using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeDAL _cidadeDAL;

        //construtor
        public CidadeService(ICidadeDAL cidadeDAL)
        {
            _cidadeDAL = cidadeDAL;
        }

        /// <summary>
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Cidade cidade)
        {
            return await _cidadeDAL.Delete(cidade);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            return await _cidadeDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Cidade>> GetAll()
        {
            return await _cidadeDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Cidade>> GetByID(int id)
        {
            return await _cidadeDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Cidade>> GetByNameAndEstadoId(Cidade cidade)
        {
            return await _cidadeDAL.GetByNameAndEstadoId(cidade);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _cidadeDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _cidadeDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Cidade cidade)
        {
            return await _cidadeDAL.Insert(cidade);
        }

        /// <summary>
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Cidade cidade)
        {
            return await _cidadeDAL.InsertReturnId(cidade);
        }

        /// <summary>
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public async Task<Response> Update(Cidade cidade)
        {
            return await _cidadeDAL.Update(cidade);
        }
    }
}