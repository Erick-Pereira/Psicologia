using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class BairroService : IBairroService
    {
        private readonly IBairroDAL _bairroDAL;

        public BairroService(IBairroDAL bairroDAL)
        {
            _bairroDAL = bairroDAL;
        }

        public async Task<Response> Delete(Bairro bairro)
        {
            return await _bairroDAL.Delete(bairro);
        }

        public async Task<DataResponse<Bairro>> GetAll()
        {
            return await _bairroDAL.GetAll();
        }

        public async Task<SingleResponse<Bairro>> GetByID(int id)
        {
            return await _bairroDAL.GetByID(id);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _bairroDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _bairroDAL.IniciarReturnId();
        }

        public async Task<Response> Insert(Bairro bairro)
        {
            return await _bairroDAL.Insert(bairro);
        }

        public async Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            return await _bairroDAL.InsertReturnId(bairro);
        }

        public async Task<Response> Update(Bairro bairro)
        {
            return await _bairroDAL.Update(bairro);
        }
    }
}