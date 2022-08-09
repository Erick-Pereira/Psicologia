using BusinessLogicalLayer.Constants;
using Entities;
using FluentValidation;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class UpdateFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public UpdateFuncionarioValidator()
        {
            RuleFor(f => f.ID).GreaterThan(0).WithMessage(GenericConstants.MENSAGEM_ERRO_ID_OBRIGATORIO);
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO)
                                .Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
        }
    }
}