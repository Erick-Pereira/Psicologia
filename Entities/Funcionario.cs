namespace Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
    }
}