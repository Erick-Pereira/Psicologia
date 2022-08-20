using Entities;
using VisualLayer.Models.Departamento;
using VisualLayer.Models.Funcionario;

namespace VisualLayer.Models.Equipe
{
    public class EquipeInsertViewModel
    {
        public string Nome { get; set; }
        public List<FuncionarioSelectViewModel> Funcionarios { get; set; }
        public DepartamentoSelectViewModel Departamento { get; set; }
    }
}
