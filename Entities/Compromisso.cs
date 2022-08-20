﻿namespace Entities
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}