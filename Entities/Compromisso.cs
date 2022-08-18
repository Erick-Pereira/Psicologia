using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Compromisso
    {
        public int Id {get;set;}
        public string Descricao { get;set;}
        public DateTime Data { get;set;}
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
