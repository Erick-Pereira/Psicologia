using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioUpdateViewModel
    {
        [Required(ErrorMessage = "O Nome deve ser informado.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve conter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O CPF deve ser informado.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O CEP deve ser informado.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Numero da casa deve ser informado.")]
        [Display(Name = "Numero da casa")]
        public string NumeroCasa { get; set; }
        [Required(ErrorMessage = "A Rua deve ser informada.")]
        public string Rua { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O Bairro deve ser informado.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "A Cidade deve ser informada.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O Estao deve ser informado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O Email deve ser informado.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve conter entre 5 e 100 caracteres.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de nascimento deve ser informada.")]
        public DateTime DataNascimento { get; set; }
    }
}
