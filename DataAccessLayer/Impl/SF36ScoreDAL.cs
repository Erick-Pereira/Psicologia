﻿using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class SF36ScoreDAL : ISFScoreDAL
    {
        private readonly DataBaseDbContext _db;

        public SF36ScoreDAL(DataBaseDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Recebe um SF36 e Deleta no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Delete(SF36Score score)
        {
            try
            {
                _db.Remove(score);
                await _db.SaveChangesAsync();
                return ResponseFactory<SF36Score>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        public async Task<DataResponse<SF36Score>> GetAllByFuncionario(Funcionario funcionario)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessDataResponse(await _db.Score.Where(s => s.FuncionarioID == funcionario.ID).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Funcionario e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo todos os SF36 ligados a um Funcionario</returns>
        public async Task<DataResponse<SF36Score>> GetAllByFuncionario(int id)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessDataResponse(await _db.Score.Where(s => s.FuncionarioID == id).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Funcionario e uma data e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        public async Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(int id, DateTime data)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessItemResponse(await _db.Score.FirstOrDefaultAsync(s => s.FuncionarioID == id && s.DataSF == data));
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um Funcionario e uma data e busca todos os SF36 ligados a ele
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="data"></param>
        /// <returns>Retorna um SingleResponse contendo todos os SF36 ligados a um Funcionario que foram feitos na data informada</returns>
        public async Task<SingleResponse<SF36Score>> GetByFuncionarioAndDate(Funcionario funcionario, DateTime data)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessItemResponse(await _db.Score.FirstOrDefaultAsync(s => s.FuncionarioID == funcionario.ID && s.DataSF == data));
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um ID de Funcionario e uma data e busca os ultimos 3 SF36 ligados a ele
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um DataResponse contendo os ultimos 3 SF36 ligados ao Funcionario informado</returns>
        public async Task<DataResponse<SF36Score>> GetLast3SFByFuncionario(int id)
        {
            try
            {
                return ResponseFactory<SF36Score>.CreateSuccessDataResponse(await _db.Score.Where(s => s.FuncionarioID == id).OrderByDescending(c => c.ID).Take(3).ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        /// Recebe um SF36 e insere no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Insert(SF36Score score)
        {
            _db.Score.Add(score);
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
        /// Recebe um SF36 e faz o Update no Banco de Dados
        /// </summary>
        /// <param name="score"></param>
        /// <returns>Retorna um Response informando se teve sucesso</returns>
        public async Task<Response> Update(SF36Score score)
        {
            try
            {
                _db.Update(score);
                await _db.SaveChangesAsync();
                return ResponseFactory<SF36Score>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<SF36Score>.CreateFailureDataResponse(ex);
            }
        }
    }
}