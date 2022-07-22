using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseFactory
    {
        public static Response CreateSuccessResponse()
        {
            return new Response()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso."
            };
        }

        public static Response CreateFailureResponse()
        {
            return new Response()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm"
            };
        }
        public static Response CreateFailureResponse(string mensagem)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = mensagem
            };
        }
    }
}
