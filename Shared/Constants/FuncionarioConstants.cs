namespace Shared.Constants
{
    public class FuncionarioConstants
    {
        public const string MENSAGEM_ERRO_BAIRRO_OBRIGATORIO = "Bairro deve ser informado";
        public const string MENSAGEM_ERRO_CEP_INVALIDO = "Cep invalido";
        public const string MENSAGEM_ERRO_CEP_OBRIGATORIO = "Cep deve ser informado";
        public const string MENSAGEM_ERRO_CIDADE_OBRIGATORIA = "Cidade deve ser informada";
        public const string MENSAGEM_ERRO_CPF_FORMATO_INVALIDO = "CPF com formato inválido.";
        public const string MENSAGEM_ERRO_CPF_OBRIGATORIO = "CPF deve ser informado.";
        public const string MENSAGEM_ERRO_DATA_NASCIMENTO_INVALIDA = "Data de Nascimento invalida";
        public const string MENSAGEM_ERRO_DATA_NASCIMENTO_OBRIGATORIA = "Data de Nascimento precisa ser informada";
        public const string MENSAGEM_ERRO_EMAIL_INVALIDO = "Email inválido.";
        public const string MENSAGEM_ERRO_EMAIL_OBRIGATORIO = "Email deve ser informado.";
        public const string MENSAGEM_ERRO_ESTADO_OBRIGATORIO = "Estado deve ser informado";
        public const string MENSAGEM_ERRO_NOME_OBRIGATORIO = "Nome deve ser informado.";
        public const string MENSAGEM_ERRO_RUA_OBRIGATORIA = "Rua deve ser informada";
        public const int TAMANHO_CPF = 11;
        public const int TAMANHO_MAXIMO_EMAIL = 100;

        public const int TAMANHO_MAXIMO_NOME = 100;

        public const int TAMANHO_MINIMO_EMAIL = 5;

        public const int TAMANHO_MINIMO_NOME = 3;

        public static string MENSAGEM_ERRO_CPF_COMPRIMENTO
        { get { return $"CPF deve conter {TAMANHO_CPF} caracteres"; } }

        public static string MENSAGEM_ERRO_EMAIL_COMPRIMENTO
        { get { return $"Email deve conter entre {TAMANHO_MINIMO_EMAIL} e {TAMANHO_MAXIMO_EMAIL} caracteres."; } }

        public static string MENSAGEM_ERRO_NOME_COMPRIMENTO
        { get { return $"Nome deve conter entre {TAMANHO_MINIMO_NOME} e {TAMANHO_MAXIMO_NOME} caracteres."; } }
    }
}