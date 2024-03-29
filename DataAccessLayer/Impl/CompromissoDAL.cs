﻿using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    //ESSA CLASSE NÃO ESTA SENDO USADA NO MOMENTO
    public class CompromissoDAL : ICompromissoDAL
    {
        private readonly DataBaseDbContext _db;

        public CompromissoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Compromisso compromisso)
        {
            _db.Compromisso.Remove(compromisso);
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
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> Delete(int id)
        {
            _db.Compromisso.Remove(new Compromisso() { ID = id });
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
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<Compromisso>> GetAll()
        {
            try
            {
                DataResponse<Compromisso> dataResponse = new()
                {
                    Data = await _db.Compromisso.ToListAsync()
                };
                return dataResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Compromisso>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Compromisso>> GetByID(int id)
        {
            try
            {
                SingleResponse<Compromisso> singleResponse = new()
                {
                    Item = await _db.Compromisso.FindAsync(id)
                };
                return singleResponse;
            }
            catch (Exception ex)
            {
                return ResponseFactory<Compromisso>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Compromisso compromisso)
        {
            _db.Compromisso.Add(compromisso);
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
        ///
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public async Task<Response> Update(Compromisso compromisso)
        {
            _db.Compromisso.Update(compromisso);
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