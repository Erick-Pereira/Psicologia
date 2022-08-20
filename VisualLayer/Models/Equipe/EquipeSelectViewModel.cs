using Entities;
using VisualLayer.Models.Departamento;

namespace VisualLayer.Models.Equipe
{
    public class EquipeSelectViewModel
    {
        public string Nome { get; set; }
        public List<Entities.Funcionario> Funcionarios { get; set; }
        public DepartamentoSelectViewModel Departamento { get; set; }
    }
}