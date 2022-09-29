using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IEnderecoDAL
    {
        /// <summary>
        /// Recebe um ID de Bairro e Conta quantos Enderecos estão ligados a esse Bairro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Enderecos ligados a um Bairro</returns>
        Task<SingleResponse<int>> CountAllByBairroId(int id);

        /// <summary>
        /// Recebe um Endereco e Deleta no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(Endereco endereco);

        /// <summary>
        /// Recebe um ID de Endereco e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Delete(int id);

        /// <summary>
        /// Busca todos os Enderecos registrados no Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Enderecos registrados no Banco de Dados</returns>
        Task<DataResponse<Endereco>> GetAll();

        /// <summary>
        /// Recebe um Endereco contendo rua,numero da casa, CEP e ID de Bairro e Busca no Banco de Dados um Bairro com as mesmas informações
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um SingleResponse contendo um Endereco com as mesmas informações recebidas</returns>
        Task<SingleResponse<Endereco>> GetByEndereco(Endereco endereco);

        /// <summary>
        /// Recebe um ID de Endereco e Busca todas as informações referentes ao ID informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo um Endereco referente ao ID informado</returns>
        Task<SingleResponse<Endereco>> GetByID(int id);

        /// <summary>
        /// Conta quantos Enderecos tem valores vazios para o primeiro registro
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Enderecos com valores vazios</returns>
        Task<SingleResponse<int>> Iniciar();

        /// <summary>
        /// Busca um Endereco com cep e rua vazio
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo um Endereco</returns>
        Task<SingleResponse<int>> IniciarReturnId();

        /// <summary>
        /// Recebe um Endereco e Insere no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Insert(Endereco endereco);

        /// <summary>
        /// Recebe um Endereco e Insere no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um SingleResponse contendo o ID do Endereco inserido</returns>
        Task<SingleResponse<int>> InsertReturnId(Endereco endereco);

        /// <summary>
        /// Recebe um Endereco e faz Update no Banco de Dados
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        Task<Response> Update(Endereco endereco);
    }
}