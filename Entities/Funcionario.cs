namespace Entities
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
    }
}