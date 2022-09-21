namespace Entities
{
    public class Equipe
    {
        public int ID { get; set; }

        public ICollection<EquipeFuncionario> Funcionarios { get; set; }

        public string Nome { get; set; }
    }
}