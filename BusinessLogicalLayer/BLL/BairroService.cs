using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class BairroService : IBairroService
    {
        private readonly IBairroDAL _bairroDAL;

        // Construtor do BairroService
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
        /// Recebe um ID e chama o metodo CountAllByCidadeId do BairroDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Bairros ligados a uma Cidade</returns>
        public async Task<SingleResponse<int>> CountAllByCidadeId(int id)
        {
            return await _bairroDAL.CountAllByCidadeId(id);
        }

        /// <summary>
        /// Recebe um ID e chama o metodo GetByID do BairroDAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Bairro referente ao ID</returns>
        public async Task<SingleResponse<Bairro>> GetByID(int id)
        {
            return await _bairroDAL.GetByID(id);
        }

        /// <summary>
        /// Recebe um Bairro contendo um Nome e um ID de Cidade e chama o metodo GetByNameAndCidadeId do BairroDAL
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo um Bairro que contenha as mesmas informações passadas</returns>
        public async Task<SingleResponse<Bairro>> GetByNameAndCidadeId(Bairro bairro)
        {
            return await _bairroDAL.GetByNameAndCidadeId(bairro);
        }

        /// <summary>
        /// Chama o metodo Iniciar do BairroDAL e verifica se tem pelo menos 1 Bairro com nome vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse informando se tem pelo menos um Bairro com nome vazio</returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _bairroDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// Chama o metodo IniciarReturnId do BairroDAL
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID do Bairro</returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _bairroDAL.IniciarReturnId();
        }

        /// <summary>
        /// Recebe um Bairro e chama o metodo Insert do BairroDAL
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Insert(Bairro bairro)
        {
            return await _bairroDAL.Insert(bairro);
        }

        /// <summary>
        /// Recebe um Bairro e chama o metodo InsertReturnId do BairroDAL
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Bairro inserido</returns>
        public async Task<SingleResponse<int>> InsertReturnId(Bairro bairro)
        {
            return await _bairroDAL.InsertReturnId(bairro);
        }

        /// <summary>
        /// Recebe um Bairro e chama o metodo Update do BairroDAL
        /// </summary>
        /// <param name="bairro"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Update(Bairro bairro)
        {
            return await _bairroDAL.Update(bairro);
        }
    }
}