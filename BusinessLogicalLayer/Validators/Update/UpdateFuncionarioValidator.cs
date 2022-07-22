using BusinessLogicalLayer;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    internal class UpdateFuncionarioValidator : AbstractValidator<Funcionario>
    {
        public UpdateFuncionarioValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage(GenericConstants.MENSAGEM_ERRO_ID_OBRIGATORIO);
            RuleFor(f => f.Nome).NotEmpty().WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO)
                                .Length(3, 20).WithMessage(FuncionarioConstants.MENSAGEM_ERRO_NOME_COMPRIMENTO);
        }
    }
}
