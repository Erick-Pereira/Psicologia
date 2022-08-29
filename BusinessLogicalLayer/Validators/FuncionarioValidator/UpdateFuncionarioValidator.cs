using Entities;
using FluentValidation;
using Shared.Constants;

namespace BusinessLogicalLayer.Validators.FuncionarioValidator
{
    internal class UpdateFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public UpdateFuncionarioValidator()
        {
            RuleFor(f => f.Cpf).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_CPF).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_COMPRIMENTO).Must(Validator.IsCpf).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CPF_FORMATO_INVALIDO); 
            RuleFor(f => f.DataNascimento).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_DATA_NASCIMENTO_OBRIGATORIA); 
            RuleFor(f => f.Endereco.Bairro.Cidade.EstadoId).NotEmpty(); 
            RuleFor(f => f.Endereco.Bairro.Cidade.NomeCidade).NotEmpty(); 
            RuleFor(f => f.Endereco.Bairro.NomeBairro).NotEmpty(); 
            RuleFor(f => f.Endereco.CEP).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_CEP_OBRIGATORIO); 
            RuleFor(f => f.Endereco.NumeroCasa).NotEmpty(); 
            RuleFor(f => f.ID).GreaterThan(0).WithMessage(GenericConstants.MENSAGEM_ERRO_ID_OBRIGATORIO); 
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO).Length(FuncionarioConstants.TAMANHO_MINIMO_NOME, FuncionarioConstants.TAMANHO_MAXIMO_NOME).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO); 
            RuleFor(f => f.Senha).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_SENHA_OBRIGATORIA).Length(FuncionarioConstants.TAMANHO_MINIMO_SENHA,FuncionarioConstants.TAMANHO_MAXIMO_SENHA).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_SENHA_COMPRIMENTO);
        }
    }
}