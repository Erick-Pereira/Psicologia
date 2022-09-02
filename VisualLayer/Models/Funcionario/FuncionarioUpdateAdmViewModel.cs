﻿using Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioUpdateAdmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO)]
        [StringLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME, MinimumLength = FuncionarioConstants.TAMANHO_MINIMO_NOME, ErrorMessage = "O Nome deve conter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = FuncionarioConstants.MENSAGEM_ERRO_CPF_OBRIGATORIO)]
        [StringLength(FuncionarioConstants.TAMANHO_CPF, ErrorMessage = "CPF deve conter 14 caracteres.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado.")]
        [StringLength(FuncionarioConstants.TAMANHO_MAXIMO_EMAIL, MinimumLength = FuncionarioConstants.TAMANHO_MINIMO_EMAIL, ErrorMessage = $"O Email deve conter entre 5 e 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Cargo deve ser informado.")]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "O Salario deve ser informado.")]
        public double Salario { get; set; }
    }
}