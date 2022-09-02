using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioSelectViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        public Entities.Cargo Cargo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        public double Salario { get; set; }
    }
}