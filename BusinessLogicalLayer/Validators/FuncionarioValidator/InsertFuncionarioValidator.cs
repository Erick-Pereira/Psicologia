using Entities;
using FluentValidation;
using Shared.Constants;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class InsertFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public InsertFuncionarioValidator()
        {
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
            RuleFor(f => f.Email).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_EMAIL, FuncionarioConstants.TAMANHO_MAXIMO_EMAIL).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_COMPRIMENTO).EmailAddress().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_INVALIDO);
            RuleFor(f => f.Cargo).NotEmpty();
        }
    }
}