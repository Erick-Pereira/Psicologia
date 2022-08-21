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

        public Task<Response> Delete(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Endereco>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Endereco>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _enderecoDAL.Iniciar();
            return ResponseFactory<bool>.CreateSuccessItemResponse(response.Item < 1);
        }

        public Task<Response> Insert(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}