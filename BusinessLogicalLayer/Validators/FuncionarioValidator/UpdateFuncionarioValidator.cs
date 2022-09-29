using Entities;
using FluentValidation;
using Shared.Constants;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class UpdateFuncionarioValidator : AbstractValidator<Funcionario>
    {
        /// <summary>
        /// faz todas as validações para fazer o update no Banco de Dados
        /// </summary>
        public UpdateFuncionarioValidator()
        {
            RuleFor(f => f.Cpf).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_CPF).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_COMPRIMENTO).Must(Validator.IsCpf).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_FORMATO_INVALIDO);
            RuleFor(f => f.DataNascimento).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_DATA_NASCIMENTO_OBRIGATORIA);
            RuleFor(f => f.Endereco.Bairro.Cidade.Estado).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_ESTADO_OBRIGATORIO);
            RuleFor(f => f.Endereco.Bairro.Cidade.NomeCidade).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CIDADE_OBRIGATORIA);
            RuleFor(f => f.Endereco.Bairro.NomeBairro).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_BAIRRO_OBRIGATORIO);
            RuleFor(f => f.Endereco.CEP).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CEP_OBRIGATORIO).Must(Validator.isCEP).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CEP_INVALIDO);
            RuleFor(f => f.Endereco.NumeroCasa).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NUMERO_CASA_OBRIGATORIO);
            RuleFor(f => f.ID).GreaterThan(0).WithMessage(GenericConstants.MENSAGEM_ERRO_ID_OBRIGATORIO);
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
        }
    }
}