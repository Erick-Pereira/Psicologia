namespace Shared
{
    public class ResponseFactory<T>
    {
        public static Response CreateSuccessResponse()
        {
            return new Response()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso."
            };
        }

        public static SingleResponse<T> CreateItemResponse(string message, bool hasSuccess, T objeto)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = hasSuccess,
                Message = message,
                Item = objeto
            };
        }

        public static SingleResponse<T> CreateSuccessItemResponse(T objeto)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso.",
                Item = objeto
            };
        }

        public static DataResponse<T> CreateSuccessDataResponse(List<T> objetos)
        {
            return new DataResponse<T>()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso.",
                Data = objetos
            };
        }

        public static Response CreateFailureResponse(Exception ex)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        public static SingleResponse<T> CreateFailureItemResponse(Exception ex)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        public static DataResponse<T> CreateFailureDataResponse(Exception ex)
        {
            return new DataResponse<T>()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        public static Response CreateFailureResponse(string mensagem, Exception ex)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }

        public static Response CreateFailureResponse(string mensagem)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = mensagem,
            };
        }

        public static SingleResponse<T> CreateFailureItemResponse(string mensagem, Exception ex)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }

        public static DataResponse<T> CreateFailureDataResponse(string mensagem, Exception ex)
        {
            return new DataResponse<T>()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }
    }
}