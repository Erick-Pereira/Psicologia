using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Cargo
{
    public class CargoSelectViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Função")]
        public string Funcao { get; set; }

        [Display(Name = "Nivel de Permissão")]
        public int NivelPermissao { get; set; }
    }
}