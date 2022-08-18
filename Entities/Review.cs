namespace Entities
{
    public class Review
    {
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public double Comunicacao { get; set; }
        public double TrabalhoEmEquipe { get; set; }
        public double Iniciativa { get; set; }
        public double Lideranca { get; set; }
        public double Organizacao { get; set; }
    }
}