using Entities;
using Entities.Interfaces;
using Shared;

namespace DataAcessLayer
{
    public class FuncionarioDAL : IFuncionarioService
    {
        public Response Delete(Funcionario funcionario)
        {
            DataBaseDbContext db = new();
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
            DataBaseDbContext db = new();
            DataResponse<Funcionario> dataResponse = new()
            {
                Data = db.Funcionario.ToList()
            };
            return dataResponse;
        }

        public SingleResponse<Funcionario> GetByID(int id)
        {
            DataBaseDbContext db = new();
            SingleResponse<Funcionario> singleResponse = new()
            {
                Item = db.Funcionario.Find(id)
            };
            return singleResponse;
        }



        public Response Insert(Funcionario funcionario)
        {
            DataBaseDbContext db = new();
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
            DataBaseDbContext db = new();
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
        public SingleResponse<int> GetByLogin(Funcionario funcionario)
        {
            try
            {
                DataBaseDbContext db = new();
                SingleResponse<int> singleResponse = new()
                {
                    Item = db.Funcionario.Where(f => f.Email == funcionario.Email && f.Senha == funcionario.Senha).Count()
                };
                return singleResponse;
            }
            catch (Exception)
            {
                return new SingleResponse<int>()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o adm"
                };
            }
        }
}
}