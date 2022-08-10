using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
