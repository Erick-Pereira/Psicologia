namespace Entities
{
    public class Equipe
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}