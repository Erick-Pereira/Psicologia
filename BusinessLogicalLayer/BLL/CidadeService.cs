using BusinessLogicalLayer.Interfaces;
using DataAcessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeDAL _cidadeDAL;

        public CidadeService(ICidadeDAL cidadeDAL)
        {
            _cidadeDAL = cidadeDAL;
        }

        public async Task<Response> Delete(Cidade cidade)
        {
            return await _cidadeDAL.Delete(cidade);
        }

        public async Task<DataResponse<Cidade>> GetAll()
        {
            return await _cidadeDAL.GetAll();
        }

        public async Task<SingleResponse<Cidade>> GetByID(int id)
        {
            return await _cidadeDAL.GetByID(id);
        }

        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _cidadeDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        public async Task<SingleResponse<int>> IniciarReturnId()
        {
           return await _cidadeDAL.IniciarReturnId();
        }

        public async Task<Response> Insert(Cidade cidade)
        {
            return await _cidadeDAL.Insert(cidade);
        }

        public async Task<SingleResponse<int>> InsertReturnId(Cidade cidade)
        {
            return await _cidadeDAL.InsertReturnId(cidade);
        }

        public async Task<Response> Update(Cidade cidade)
        {
            return await _cidadeDAL.Update(cidade);
        }
    }
}