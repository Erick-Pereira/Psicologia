namespace Entities
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public double Salario { get; set; }
        public string Foto { get; set; }
        public string CarteiraTrabalho { get; set; }
        public bool IsFirstLogin { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EnderecoID { get; set; }
        public Endereco Endereco { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
        public ICollection<EquipeFuncionario> Equipes { get; set; }
    }
}