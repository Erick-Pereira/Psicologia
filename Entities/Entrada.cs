namespace Entities
{
    public class Entrada
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}