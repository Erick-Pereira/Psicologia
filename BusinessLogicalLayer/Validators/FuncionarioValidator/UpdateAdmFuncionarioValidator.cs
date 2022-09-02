using Entities;
using FluentValidation;
using Shared.Constants;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    public class UpdateAdmFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public UpdateAdmFuncionarioValidator()
        {
            RuleFor(f => f.Cpf).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_CPF).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_COMPRIMENTO).Must(Validator.IsCpf).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_FORMATO_INVALIDO);
            RuleFor(f => f.ID).GreaterThan(0).WithMessage(GenericConstants.MENSAGEM_ERRO_ID_OBRIGATORIO);
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
            RuleFor(f => f.Email).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_EMAIL, FuncionarioConstants.TAMANHO_MAXIMO_EMAIL).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_COMPRIMENTO).EmailAddress().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_EMAIL_INVALIDO);
            RuleFor(f => f.CargoID).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CARGO_OBRIGATORIO);
        }
    }
}