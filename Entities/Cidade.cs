namespace Entities
{
    public class Cidade
    {
        public int ID { get; set; }

        public Estado Estado { get; set; }

        public int EstadoId { get; set; }

        public string NomeCidade { get; set; }
    }
}