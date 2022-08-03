using Entities;
using FluentValidation;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class InsertFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public InsertFuncionarioValidator()
        {
            RuleFor(f => f.Nome).NotEmpty()
                .WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO)
                .Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME)
                .WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
        }
    }
}