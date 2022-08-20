using Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME, MinimumLength = FuncionarioConstants.TAMANHO_MINIMO_NOME, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado.")]
        [StringLength(FuncionarioConstants.TAMANHO_MAXIMO_EMAIL, MinimumLength = FuncionarioConstants.TAMANHO_MINIMO_EMAIL, ErrorMessage = $"O Email deve conter entre 5 e 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF deve ser informado.")]
        [StringLength((FuncionarioConstants.TAMANHO_CPF) + 3, ErrorMessage = "CPF deve conter 11 caracteres")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Cargo deve ser informado.")]
        public Entities.Cargo Cargo { get; set; }
    }
}