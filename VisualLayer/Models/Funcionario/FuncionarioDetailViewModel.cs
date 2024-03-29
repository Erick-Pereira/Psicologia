﻿using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Funcionario
{
    public class FuncionarioDetailViewModel
    {
        public string Id { get; set; }

        public string Foto { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Celular { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        public Entities.Cargo Cargo { get; set; }

        public double Salario { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Numero da casa")]
        public string NumeroCasa { get; set; }

        public string Rua { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Genero Genero { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }
    }
}