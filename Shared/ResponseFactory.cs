namespace Shared
{
    public class ResponseFactory<T>
    {
        /// <summary>
        /// Recebe uma Exception e Cria um DataResponse informando que houve uma falha
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna um DataResponse de qualquer tipo informando que houve um erro</returns>
        public static DataResponse<T> CreateFailureDataResponse(Exception ex)
        {
            return new DataResponse<T>()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma String contendo uma mensagem e uma Exception e Cria um DataResponse informando que houve uma falha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="ex"></param>
        /// <returns>Retorna um DataResponse de qualquer tipo informando que houve um erro</returns>
        public static DataResponse<T> CreateFailureDataResponse(string mensagem, Exception ex)
        {
            return new DataResponse<T>()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma Exception e Cria um SingleResponse informando que houve uma falha
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna um SingleResponse de qualquer tipo informando que houve um erro</returns>
        public static SingleResponse<T> CreateFailureItemResponse(Exception ex)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma String contendo uma mensagem e uma Exception e Cria um SingleResponse informando que houve uma falha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="ex"></param>
        /// <returns>Retorna um SingleResponse de qualquer tipo informando que houve um erro</returns>
        public static SingleResponse<T> CreateFailureItemResponse(string mensagem, Exception ex)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma Exception e Cria um Response informando que houve uma falha
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna um Response informando que houve um erro</returns>
        public static Response CreateFailureResponse(Exception ex)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = "Erro no banco, contate o adm",
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma String contendo uma mensagem e uma Exception e Cria um Response informando que houve uma falha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="ex"></param>
        /// <returns>Retorna um Response informando que houve um erro</returns>
        public static Response CreateFailureResponse(string mensagem, Exception ex)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = mensagem,
                Exception = ex
            };
        }

        /// <summary>
        /// Recebe uma String contendo uma mensagem e Cria um Response informando que houve uma falha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <returns>Retorna um Response informando que houve um erro</returns>
        public static Response CreateFailureResponse(string mensagem)
        {
            return new Response()
            {
                HasSuccess = false,
                Message = mensagem,
            };
        }

        /// <summary>
        /// Recebe uma String contendo uma mensagem, uma boolean e um objeto e Cria um SingleResponse
        /// </summary>
        /// <param name="message"></param>
        /// <param name="hasSuccess"></param>
        /// <param name="objeto"></param>
        /// <returns>Retorna um SingleResponse de qualquer objeto</returns>
        public static SingleResponse<T> CreateItemResponse(string message, bool hasSuccess, T objeto)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = hasSuccess,
                Message = message,
                Item = objeto
            };
        }

        /// <summary>
        /// Recebe uma Lista de um objeto e cria um DataResponse informando que houve sucesso
        /// </summary>
        /// <param name="objetos"></param>
        /// <returns>Retorna um DataResponse de qualquer objeto informando que houve sucesso</returns>
        public static DataResponse<T> CreateSuccessDataResponse(List<T> objetos)
        {
            return new DataResponse<T>()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso.",
                Data = objetos
            };
        }

        /// <summary>
        /// Recebe um objeto e cria um SingleResponse informando que houve sucesso
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>Retorna um SingleResponse de qualquer objeto informando que houve sucesso</returns>
        public static SingleResponse<T> CreateSuccessItemResponse(T objeto)
        {
            return new SingleResponse<T>()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso.",
                Item = objeto
            };
        }

        /// <summary>
        /// Cria um Response informando que houve sucesso
        /// </summary>
        /// <returns>Retorna um Response informando que houve sucesso</returns>
        public static Response CreateSuccessResponse()
        {
            return new Response()
            {
                HasSuccess = true,
                Message = "Operação realizada com sucesso."
            };
        }
    }
}