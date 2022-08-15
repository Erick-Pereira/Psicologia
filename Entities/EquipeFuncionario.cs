namespace Entities
{
    public class EquipeFuncionario
    {
        public int EquipeID { get; set; }
        public Equipe Equipe { get; set; }
        public int FuncionarioID { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}