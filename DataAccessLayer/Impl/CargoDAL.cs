﻿using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class CargoDAL : ICargoDAL
    {
        private readonly DataBaseDbContext _db;

        public CargoDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Delete(Cargo cargo)
        {
            _db.Cargo.Remove(cargo);
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
            _db.Cargo.Remove(new Cargo() { ID = id });
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
        public async Task<DataResponse<Cargo>> GetAll()
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessDataResponse(await _db.Cargo.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureDataResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SingleResponse<Cargo>> GetByID(int id)
        {
            try
            {
                return ResponseFactory<Cargo>.CreateSuccessItemResponse(await _db.Cargo.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Cargo>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> Iniciar()
        {
            try
            {
                return ResponseFactory<int>.CreateSuccessItemResponse(await _db.Cargo.Where(c => c.NivelPermissao == 0).CountAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<SingleResponse<int>> IniciarReturnId()
        {
            try
            {
                Cargo cargo = await _db.Cargo.FirstOrDefaultAsync(c => c.NivelPermissao == 0);

                return ResponseFactory<int>.CreateSuccessItemResponse(cargo.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Insert(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
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
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<SingleResponse<int>> InsertReturnId(Cargo cargo)
        {
            _db.Cargo.Add(cargo);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<int>.CreateSuccessItemResponse(cargo.ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.CreateFailureItemResponse(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public async Task<Response> Update(Cargo cargo)
        {
            _db.Cargo.Update(cargo);
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