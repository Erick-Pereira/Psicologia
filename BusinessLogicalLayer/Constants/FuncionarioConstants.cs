namespace BusinessLogicalLayer.Constants
{
    internal class FuncionarioConstants
    {
        public const string MENSAGEM_ERRO_CPF_FORMATO_INVALIDO = "CPF com formato inválido.";
        public const string MENSAGEM_ERRO_CPF_OBRIGATORIO = "CPF deve ser informado.";
        public const string MENSAGEM_ERRO_EMAIL_INVALIDO = "Email inválido.";
        public const string MENSAGEM_ERRO_EMAIL_OBRIGATORIO = "Email deve ser informado.";
        public const string MENSAGEM_ERRO_NOME_COMPRIMENTO = "Nome deve contre entre 3 e 100 caracteres.";
        public const string MENSAGEM_ERRO_NOME_OBRIGATORIO = "Nome deve ser informado.";
        public const string MENSAGEM_ERRO_RG_OBRIGATORIO = "RG precisa ser informado";
        public const int TAMANHO_CPF = 11;
        public const int TAMANHO_MAXIMO_EMAIL = 100;
        public const int TAMANHO_MAXIMO_NOME = 100;
        public const int TAMANHO_MINIMO_EMAIL = 5;
        public const int TAMANHO_MINIMO_NOME = 3;
        public readonly string MENSAGEM_ERRO_EMAIL_COMPRIMENTO_MAXIMO = $"Email não pode conter mais que {TAMANHO_MAXIMO_EMAIL} caracteres.";

        public readonly string MENSAGEM_ERRO_EMAIL_COMPRIMENTO_MINIMO = $"Email não pode conter menos que {TAMANHO_MINIMO_EMAIL} caracteres.";

        public static string MENSAGEM_666
        { get { return ""; } }

        public static string MENSAGEM_ERRO_CPF_COMPRIMENTO
        { get { return $"CPF deve conter {TAMANHO_CPF} caracteres"; } }
    }
}