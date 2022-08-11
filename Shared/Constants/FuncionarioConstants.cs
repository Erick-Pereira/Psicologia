namespace Shared.Constants
{
    public class FuncionarioConstants
    {
        public const string MENSAGEM_ERRO_CPF_FORMATO_INVALIDO = "CPF com formato inválido.";
        public const string MENSAGEM_ERRO_CPF_OBRIGATORIO = "CPF deve ser informado.";
        public const string MENSAGEM_ERRO_EMAIL_INVALIDO = "Email inválido.";
        public const string MENSAGEM_ERRO_EMAIL_OBRIGATORIO = "Email deve ser informado.";
        public const string MENSAGEM_ERRO_NOME_OBRIGATORIO = "Nome deve ser informado.";
        public const string MENSAGEM_ERRO_RG_OBRIGATORIO = "RG precisa ser informado";
        public const int TAMANHO_CPF = 11;
        public const int TAMANHO_MAXIMO_EMAIL = 100;
        public const int TAMANHO_MAXIMO_NOME = 100;
        public const int TAMANHO_MINIMO_EMAIL = 5;
        public const int TAMANHO_MINIMO_NOME = 3;  

        public static string MENSAGEM_ERRO_CPF_COMPRIMENTO
        { get { return $"CPF deve conter {TAMANHO_CPF} caracteres"; } }

        public static string MENSAGEM_ERRO_NOME_COMPRIMENTO
        { get { return $"Nome deve contre entre {TAMANHO_MINIMO_NOME} e {TAMANHO_MAXIMO_NOME} caracteres."; } }

        public static string MENSAGEM_ERRO_EMAIL_COMPRIMENTO_MAXIMO
        { get { return $"Email não pode conter mais que {TAMANHO_MAXIMO_EMAIL} caracteres."; } }

        public static string MENSAGEM_ERRO_EMAIL_COMPRIMENTO_MINIMO
        { get { return $"Email não pode conter menos que {TAMANHO_MINIMO_EMAIL} caracteres."; } }
    }
}