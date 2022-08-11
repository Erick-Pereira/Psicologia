using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve conter entre 5 e 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Cargo deve ser informado.")]
        public Entities.Cargo Cargo { get; set; }
    }
}