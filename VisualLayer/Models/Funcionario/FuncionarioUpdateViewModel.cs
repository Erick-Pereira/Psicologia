using Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioUpdateViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = FuncionarioConstants.MENSAGEM_ERRO_NOME_OBRIGATORIO)]
        [StringLength(FuncionarioConstants.TAMANHO_MAXIMO_NOME, MinimumLength = FuncionarioConstants.TAMANHO_MINIMO_NOME, ErrorMessage = "O Nome deve conter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayFormat()]
        [Required(ErrorMessage = FuncionarioConstants.MENSAGEM_ERRO_CPF_OBRIGATORIO)]
        [StringLength(FuncionarioConstants.TAMANHO_CPF, ErrorMessage = "CPF deve conter 14 caracteres.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "{000000-000}")]
        [Required(ErrorMessage = FuncionarioConstants.MENSAGEM_ERRO_CEP_OBRIGATORIO)]
        [Display(Name = "CEP")]
        [StringLength(FuncionarioConstants.TAMANHO_CEP, ErrorMessage = "CEP deve conter 9 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Numero da casa deve ser informado.")]
        [Display(Name = "Numero da casa")]
        public string NumeroCasa { get; set; }

        [Required(ErrorMessage = "A Rua deve ser informada.")]
        public string Rua { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro deve ser informado.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade deve ser informada.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estao deve ser informado.")]
        public int EstadoId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de nascimento deve ser informada.")]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        public IFormFile Image { get; set; }
    }
}