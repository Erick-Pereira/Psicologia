using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SF36Score
    {
        public int ID{ get; set; }
        public int CapacidadeFuncional { get; set; }
        public int LimitacaoAspectosFisicos { get; set; }
        public int Dor { get; set; }
        public int EstadoSaude { get; set; }
        public int Vitalidade { get; set; }
        public int AspectosSociais { get; set; }
        public int AspectosEmocionais { get; set; }
        public int SaudeMental { get; set; }
    }
}
