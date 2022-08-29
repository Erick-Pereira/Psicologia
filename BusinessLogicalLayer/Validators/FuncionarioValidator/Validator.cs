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
                return ResponseFactory<string>.CreateFailureResponse("Senha deve ser informado.");
            }
            if (senha.Contains(" "))
            {
                return ResponseFactory<string>.CreateFailureResponse("Senha não deve conter espaço.");
            }
            if (senha.Length < FuncionarioConstants.TAMANHO_MINIMO_SENHA)
            {
                return ResponseFactory<string>.CreateFailureResponse("Senha deve conter no mínimo 8 caracteres.");
            }
            if (senha.Length > FuncionarioConstants.TAMANHO_MAXIMO_SENHA)
            {
                return ResponseFactory<string>.CreateFailureResponse("senha não pode conter mais que 20 caracteres.");
            }
            return ResponseFactory<string>.CreateSuccessResponse();
        }
    }
}