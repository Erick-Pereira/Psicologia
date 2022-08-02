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
