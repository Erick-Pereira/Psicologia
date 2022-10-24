using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoDAL _estadoDAL;

        private List<Estado> estados = new List<Estado>(){
            new Estado() { NomeEstado = "Acre", Sigla="AC" },
            new Estado() { NomeEstado = "Alagoas", Sigla = "AL" },
            new Estado() { NomeEstado = "Amazonas", Sigla = "AM" },
            new Estado() { NomeEstado = "Amapá", Sigla = "AP" },
            new Estado() { NomeEstado = "Bahia", Sigla = "BA" },
            new Estado() { NomeEstado = "Ceará", Sigla = "CE" },
            new Estado() { NomeEstado = "Distrito Federal", Sigla = "DF" },
            new Estado() { NomeEstado = "Espírito Santo", Sigla = "ES" },
            new Estado() { NomeEstado = "Goiás", Sigla = "GO" },
            new Estado() { NomeEstado = "Maranhão", Sigla = "MA" },
            new Estado() { NomeEstado = "Minas Gerais", Sigla = "MG" },
            new Estado() { NomeEstado = "Mato Grosso do Sul", Sigla = "MS" },
            new Estado() { NomeEstado = "Mato Grosso", Sigla = "MT" },
            new Estado() { NomeEstado = "Pará", Sigla = "PA" },
            new Estado() { NomeEstado = "Paraíba", Sigla = "PB" },
            new Estado() { NomeEstado = "Pernambuco", Sigla = "PE" },
            new Estado() { NomeEstado = "Piauí", Sigla = "PI" },
            new Estado() { NomeEstado = "Paraná", Sigla = "PR" },
            new Estado() { NomeEstado = "Rio de Janeiro", Sigla = "RJ" },
            new Estado() { NomeEstado = "Rio Grande do Norte", Sigla = "RN" },
            new Estado() { NomeEstado = "Rondônia", Sigla = "RO" },
            new Estado() { NomeEstado = "Roraima", Sigla = "RR" },
            new Estado() { NomeEstado = "Rio Grande do Sul", Sigla = "RS" },
            new Estado() { NomeEstado = "Santa Catarina", Sigla = "SC" },
            new Estado() { NomeEstado = "Sergipe", Sigla = "SE" },
            new Estado() { NomeEstado = "São Paulo", Sigla = "SP" },
            new Estado() { NomeEstado = "Tocantins", Sigla = "TO" }
        };

        public EstadoService(IEstadoDAL estadoDAL)
        {
            _estadoDAL = estadoDAL;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<Response> VerifyEstados()
        {
            Response response = new Response();
            for (int i = 0; i < estados.Count; i++)
            {
                SingleResponse<Estado> singleResponse = await GetByUFAndName(estados[i]);
                if (singleResponse.Item == null)
                {
                    response = await Insert(estados[i]);
                    if (!response.HasSuccess)
                    {
                        return response;
                    }
                }
            }
            response.HasSuccess = true;
            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Estado estado)
        {
            return await _estadoDAL.Delete(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> Delete(int id)
        {
            return _estadoDAL.Delete(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Estado>> GetAll()
        {
            return await _estadoDAL.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Estado>> GetByID(int id)
        {
            return await _estadoDAL.GetByID(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Estado>> GetByUF(string uf)
        {
            return await _estadoDAL.GetByUF(uf);
        }

        /// <summary>
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Estado>> GetByUFAndName(Estado estado)
        {
            return await _estadoDAL.GetByUFAndName(estado);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<bool>> Iniciar()
        {
            SingleResponse<int> response = await _estadoDAL.Iniciar();
            return ResponseFactory<bool>.CreateItemResponse(response.Message, response.HasSuccess, response.Item > 0);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            return await _estadoDAL.IniciarReturnId();
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Estado estado)
        {
            return await _estadoDAL.Insert(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Estado estado)
        {
            return await _estadoDAL.InsertReturnId(estado);
        }

        /// <summary>
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<Response> Update(Estado estado)
        {
            return await _estadoDAL.Update(estado);
        }
    }
}