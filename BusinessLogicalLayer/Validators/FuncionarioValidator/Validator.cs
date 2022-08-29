using Shared;
using Shared.Constants;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class Validator
    {
        /// <summary>
        /// Executa validação de CPF utilizando as regras disponibilizadas pela Receita Federal
        /// </summary>
        /// <param name="cpf">Cpf a ser validado</param>
        /// <returns>Retorna "" se o CPF está válido, caso contrário retorna a mensagem de erro</returns>
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Verifica se a senha esta dentro dos padrões
        /// </summary>
        /// <param name="senha">Senha a ser validada</param>
        /// <returns>Retorna vazio "" caso a senha esteja correta</returns>
        public static Response ValidateSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_SENHA_OBRIGATORIA) ;
            }
            if (senha.Contains(" "))
            {
                return ResponseFactory<string>.CreateFailureResponse("Senha não deve conter espaço.");
            }
            if (senha.Length < FuncionarioConstants.TAMANHO_MINIMO_SENHA)
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_SENHA_COMPRIMENTO);
            }
            if (senha.Length > FuncionarioConstants.TAMANHO_MAXIMO_SENHA)
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_SENHA_COMPRIMENTO);
            }
            return ResponseFactory<string>.CreateSuccessResponse();
        }

        /// <summary>
        /// Verifica se o CEP esta dentro dos padrões
        /// </summary>
        /// <param name="cep">Senha a ser validada</param>
        /// <returns>Retorna vazio "" caso o CEP esteja correto</returns>
        public Response ValidateCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_CEP_OBRIGATORIO);
            }
            cep = cep.Trim();
            cep = cep.Replace("-", "").Replace(".", "");

            if (cep.Length != FuncionarioConstants.TAMANHO_CEP)
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_CEP_COMPRIMENTO);
            }
            int temp = 0;
            if (!int.TryParse(cep, out temp))
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_CEP_INVALIDO);
            }
            return ResponseFactory<string>.CreateSuccessResponse();
        }

        /// <summary>
        /// Verifica se o telefone esta dentro dos padrões
        /// </summary>
        /// <param name="telefone">Senha a ser validada</param>
        /// <returns>Retorna vazio "" caso o telefone esteja correto</returns>
        public Response ValidateTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_TELEFONE_OBRIGATORIO);
            }
            telefone = telefone.Trim();
            telefone = telefone.Replace("(", "")
                               .Replace(")", "")
                               .Replace("-", "")
                               .Replace(" ", "")
                               .Replace(".", "")
                               .Replace("+", "");
            if (telefone.Length != 8 && telefone.Length != 10 && telefone.Length != 11)
            {
                return ResponseFactory<string>.CreateFailureResponse("Telefone deve conter 8, 9, 11 ou 13 dígitos.");
            }
            long temp;
            if (!long.TryParse(telefone, out temp))
            {
                return ResponseFactory<string>.CreateFailureResponse(FuncionarioConstants.MENSAGEM_ERRO_TELEFONE_INVALIDO);
            }
            return ResponseFactory<string>.CreateSuccessResponse();
        }
    }
}