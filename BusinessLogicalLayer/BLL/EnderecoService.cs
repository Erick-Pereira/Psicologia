using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoDAL _enderecoDAL;

        //Construtor
        public EnderecoService(IEnderecoDAL enderecoDAL)
        {
            _enderecoDAL = enderecoDAL;
        }

        /// <summary>
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Endereco endereco)
        {
            return await _enderecoDAL.Delete(endereco);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            return await _enderecoDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Endereco>> GetAll()
        {
            return await _enderecoDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> GetAllByBairroId(int id)
        {
            return await _enderecoDAL.GetAllByBairroId(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Endereco>> GetByEndereco(Endereco endereco)
        {
            return await _enderecoDAL.GetByEndereco(endereco);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Endereco>> GetByID(int id)
        {
            return await _enderecoDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _enderecoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _enderecoDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Endereco endereco)
        {
            return await _enderecoDAL.Insert(endereco);
        }

        /// <summary>
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Endereco endereco)
        {
            return await _enderecoDAL.InsertReturnId(endereco);
        }

        /// <summary>
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public async Task<Response> Update(Endereco endereco)
        {
            return await _enderecoDAL.Update(endereco);
        }
    }
}