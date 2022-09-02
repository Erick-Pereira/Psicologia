namespace Entities
{
    public class Saida
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}