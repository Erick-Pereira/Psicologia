namespace Entities
{
    public class Endereco
    {
        public int ID { get; set; }
        public Bairro Bairro { get; set; }
        public int BairroID { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string NumeroCasa { get; set; }
        public string Rua { get; set; }
    }
}