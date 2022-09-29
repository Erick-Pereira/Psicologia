using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IEstadoDAL
    {
        /// <summary>
        /// Recebe um Estado e Deleta no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Estado estado);

        /// <summary>
        /// Recebe um ID de Estado e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Busca no Banco de Dados todos os Estados Registrados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Estados no Banco de Dados</returns>
        Task<DataResponse<Estado>> GetAll();

        /// <summary>
        /// Recebe um ID e busca no Banco de Dados o Estado referente ao ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado referente ao ID passado</returns>
        Task<SingleResponse<Estado>> GetByID(int id);

        /// <summary>
        /// Recebe um UF e Busca no Banco de Dados o Estado referente ao UF passado
        /// </summary>
        /// <param name="uf"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado</returns>
        Task<SingleResponse<Estado>> GetByUF(string uf);

        /// <summary>
        ///  Recebe um Estado com UF e Nome preenchidos e Busca no Banco de Dados o Estado referente ao UF e Nome passados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um SingleResponse contendo o Estado</returns>
        Task<SingleResponse<Estado>> GetByUFAndName(Estado estado);

        /// <summary>
        /// Conta a quantidade de Estados com nome e sigla vazios
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Estados com nome Vazio</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Verificar se existe um Estado com Nome e sigla vazios e busca o ID
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo o ID do Estado</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe um Estado e Insere no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Estado estado);

        /// <summary>
        /// Recebe um Estado e Insere no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Estado inserido</returns>
        Task<SingleResponse<int>> InsertReturnId(Estado estado);

        /// <summary>
        /// Recebe um Estado e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Estado estado);
    }
}