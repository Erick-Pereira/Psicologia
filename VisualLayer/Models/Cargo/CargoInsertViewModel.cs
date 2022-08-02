using System.ComponentModel.DataAnnotations;

namespace VisualLayer.Models.Cargo
{
    public class CargoInsertViewModel
    {
        [Required(ErrorMessage = "A Função deve ser informada.")]
        [Display(Name = "Função")]
        public string Funcao { get; set; }
        [Display(Name = "Nivel de Permissão")]
        [Required(ErrorMessage = "O nivel de permissão deve ser informado.")]
        [Range(0, 100, ErrorMessage = "A permissão deve estar entre 0 e 100")]
        public int NivelPermissao { get; set; }
    }
}