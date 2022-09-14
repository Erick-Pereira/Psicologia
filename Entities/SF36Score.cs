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
        public double CapacidadeFuncional { get; set; }
        public double LimitacaoAspectosFisicos { get; set; }
        public double Dor { get; set; }
        public double EstadoSaude { get; set; }
        public double Vitalidade { get; set; }
        public double AspectosSociais { get; set; }
        public double AspectosEmocionais { get; set; }
        public double SaudeMental { get; set; }
        public int FuncionarioID { get; set; }
        public Funcionario FuncionarioSF36 { get; set; }
    }
}
