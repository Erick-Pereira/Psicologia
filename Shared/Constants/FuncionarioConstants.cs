namespace Shared.Constants
{
    public class FuncionarioConstants
    {
        public const string MENSAGEM_ERRO_BAIRRO_OBRIGATORIO = "Bairro deve ser informado";
        public const string MENSAGEM_ERRO_CARGO_OBRIGATORIO = "Cargo deve ser informado";
        public const string MENSAGEM_ERRO_CEP_INVALIDO = "CEP invalido";
        public const string MENSAGEM_ERRO_CEP_OBRIGATORIO = "CEP deve ser informado";
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
        public const string MENSAGEM_ERRO_SENHA_OBRIGATORIA = "Senha deve ser informada.";
        public const string MENSAGEM_ERRO_TELEFONE_INVALIDO = "Telefone inválido.";
        public const string MENSAGEM_ERRO_TELEFONE_OBRIGATORIO = "Telefone deve ser informado.";
        public const int TAMANHO_CEP = 8;
        public const int TAMANHO_CPF = 11;
        public const int TAMANHO_MAXIMO_EMAIL = 100;
        public const int TAMANHO_MAXIMO_NOME = 100;
        public const int TAMANHO_MAXIMO_SENHA = 20;
        public const int TAMANHO_MINIMO_EMAIL = 5;
        public const int TAMANHO_MINIMO_NOME = 3;
        public const int TAMANHO_MINIMO_SENHA = 8;
        public static string MENSAGEM_ERRO_CEP_COMPRIMENTO 
        { get { return $"CEP deve conter {TAMANHO_CEP} dígitos (sem considerar hífen/ponto)."; }}
        public static string MENSAGEM_ERRO_CPF_COMPRIMENTO
        { get { return $"CPF deve conter {TAMANHO_CPF} caracteres"; } }

        public static string MENSAGEM_ERRO_EMAIL_COMPRIMENTO
        { get { return $"Email deve conter entre {TAMANHO_MINIMO_EMAIL} e {TAMANHO_MAXIMO_EMAIL} caracteres."; } }

        public static string MENSAGEM_ERRO_NOME_COMPRIMENTO
        { get { return $"Nome deve conter entre {TAMANHO_MINIMO_NOME} e {TAMANHO_MAXIMO_NOME} caracteres."; } }

        public static string MENSAGEM_ERRO_SENHA_COMPRIMENTO
        { get { return $"senha deve conter entre {TAMANHO_MINIMO_SENHA} e {TAMANHO_MAXIMO_SENHA} caracteres."; }}
    }
}