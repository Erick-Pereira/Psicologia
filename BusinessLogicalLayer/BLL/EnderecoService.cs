using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoDAL _enderecoDAL;

        public EnderecoService(IEnderecoDAL enderecoDAL)
        {
            _enderecoDAL = enderecoDAL;
        }

        public async Task<Response> Delete(Endereco endereco)
        {
            return await _enderecoDAL.Delete(endereco);
        }

        public async Task<DataResponse<Endereco>> GetAll()
        {
            return await _enderecoDAL.GetAll();
        }

        public async Task<SingleResponse<Endereco>> GetByID(int id)
        {
            return await _enderecoDAL.GetByID(id);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _enderecoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        public async Task<Response> Insert(Endereco endereco)
        {
            return await _enderecoDAL.Insert(endereco);
        }

        public async Task<SingleResponse<int>> InsertReturnId(Endereco endereco)
        {
            return await _enderecoDAL.InsertReturnId(endereco);
        }

        public async Task<Response> Update(Endereco endereco)
        {
            return await _enderecoDAL.Update(endereco);
        }
    }
}