using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Endereco
    {
        public int ID { get; set; }
        public string CEP { get; set; }
        public string NumeroCasa { get; set; }
        public int BairroID { get; set; }
        public Bairro Bairro { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
    }
}
