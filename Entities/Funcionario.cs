using Entities.Enums;

namespace Entities
{
    public class Funcionario
    {
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salario { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
        public int CargoID { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
        public ICollection<EquipeFuncionario> Equipes { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Genero Genero { get; set; }
        public bool HasRequiredTest { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsFirstLogin { get; set; }
        public int SF36ScoreID { get; set; }
        public SF36Score SfScore { get; set; }
    }
}