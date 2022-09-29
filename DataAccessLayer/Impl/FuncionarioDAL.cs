using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        private readonly DataBaseDbContext _db;

        public FuncionarioDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Recebe um ID de Endereco e conta todos os Funcionarios que estão ligados a esse Endereco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios ligados a um Endereco</returns>
        public async Task<SingleResponse<int>> CountAllByEnderecoId(int id)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.AsNoTracking().Where(f => f.EnderecoID == id).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario e Deleta no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(Funcionario funcionario)
        {
            _db.Funcionario.Remove(funcionario);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID e Deleta no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(int id)
        {
            _db.Funcionario.Remove(new Funcionario() { ID = id });
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        /// <summary>
        /// Busca todos os Funcionarios do Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Funcionarios no Banco de Dados</returns>
        public async Task<DataResponse<Funcionario>> GetAll()
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(await _db.Funcionario.AsNoTracking().Include(f => f.Cargo).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Busca todos os Funcionarios ativos do Banco de Dados
        /// </summary>
        /// <returns>Retorna um DataResponse contendo todos os Funcionarios ativos no Banco de Dados</returns>
        public async Task<DataResponse<Funcionario>> GetAllAtivos()
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(await _db.Funcionario.AsNoTracking().Where(f => f.IsAtivo == true).Include(f => f.Cargo).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Funcionario e Busca todas as informações referentes a esse ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse contendo o Funcionario referente ao ID</returns>
        public async Task<SingleResponse<Funcionario>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.AsNoTracking().Include(f => f.Cargo).Include(f => f.Endereco).Include(f => f.Endereco.Bairro).Include(f => f.Endereco.Bairro.Cidade).Include(f => f.Endereco.Bairro.Cidade.Estado).FirstOrDefaultAsync(f => f.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario com Email e Senha preenchidos e busca as informações no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um SingleResponse contendo um Funcionario</returns>
        public async Task<SingleResponse<Funcionario>> GetByLogin(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.AsNoTracking().FirstAsync(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Funcionario e Busca no Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um SingleResponse de Funcionario com apenas algumas informações preenchidas</returns>
        public async Task<SingleResponse<Funcionario>> GetInformationToVerify(int id)
        {
            try
            {
                return ResponseFactory<Funcionario>.CreateSuccessItemResponse(await _db.Funcionario.AsNoTracking().Include(f => f.Cargo).Select(f => new Funcionario { ID = f.ID, IsFirstLogin = f.IsFirstLogin, HasRequiredTest = f.HasRequiredTest, Cargo = new Cargo { NivelPermissao = f.Cargo.NivelPermissao } }).FirstOrDefaultAsync(f => f.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Conta quantos Funcionarios tem nivel de permissão 0
        /// </summary>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios com permissão 0</returns>
        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.Where(f => f.Cargo.NivelPermissao == 0).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario e Insere no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Insert(Funcionario funcionario)
        {
            _db.Funcionario.Add(funcionario);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario com Email e Senha preenchidos e conta os funcionarios com essas informações no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um SingleResponse contendo a quantidade de Funcionarios com essa informação</returns>
        public async Task<SingleResponse<int>> Logar(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Funcionario.AsNoTracking().Where(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha && f.IsAtivo == true).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<DataResponse<Funcionario>> SearchItem(string searchString)
        {
            try
            {
                List<Funcionario> funcionario = _db.Funcionario.Where(f => f.Nome.ToLower().Contains(searchString.ToLower())).ToList();
                return ResponseFactory<Funcionario>.CreateSuccessDataResponse(funcionario);
            }
            catch (Exception ex)
            {
                return ResponseFactory<Funcionario>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Update(Funcionario funcionario)
        {
            _db.Update(funcionario);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }
    }
}