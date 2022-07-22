using Entities;
using Entities.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class FuncionarioDAL : IFuncionarioService
    {
        public Response Delete(Funcionario funcionario)
        {
            DataBase db = new();
            db.Funcionario.Remove(funcionario);
            try
            {
                db.SaveChanges();
                return ResponseFactory.CreateSuccessResponse();
            }
            catch (Exception)
            {

                return ResponseFactory.CreateFailureResponse();
            }
        }

        public DataResponse<Funcionario> GetAll()
        {
            DataBase db = new();
            DataResponse<Funcionario> dataResponse = new()
            {
                Data = db.Funcionario.ToList()
            };
            return dataResponse;
        }

        public SingleResponse<Funcionario> GetByID(int id)
        {
            DataBase db = new();
            SingleResponse<Funcionario> singleResponse = new()
            {
                Item = db.Funcionario.Find(id)
            };
            return singleResponse;
        }

        public Response Insert(Funcionario funcionario)
        {
            DataBase db = new();
            db.Funcionario.Add(funcionario);
            try
            {
                db.SaveChanges();
                return ResponseFactory.CreateSuccessResponse();
            }
            catch (Exception)
            {

                return ResponseFactory.CreateFailureResponse();
            }
        }

        public Response Update(Funcionario funcionario)
        {
            DataBase db = new();
            db.Funcionario.Update(funcionario);
            try
            {
                db.SaveChanges();
                return ResponseFactory.CreateSuccessResponse();
            }
            catch (Exception)
            {

                return ResponseFactory.CreateFailureResponse();
            }
        }
    }
}
