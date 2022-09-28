using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioSelectViewModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        public Entities.Cargo Cargo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        public Genero Genero { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }

        public double Salario { get; set; }
    }



    public PartialViewResult SearchFunc(string searchText)
    {
        List<FuncionarioSelectViewModel> model = new List<FuncionarioSelectViewModel>();
        var result = model.Where(a => a.Nome.ToLower().Contains(searchText) || a.Cpf.ToString().Contains(searchText)).ToList();
        return ViewResult("Funcionario" result);
    }

}