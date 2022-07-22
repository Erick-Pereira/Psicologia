using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bairro
    {
        public int ID { get; set; }
        public string NomeBairro { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
    }
}
