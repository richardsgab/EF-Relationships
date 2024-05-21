using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models.ViewModels
{
    public class CreateBoekViewModel
    {
        [Required(ErrorMessage="Titel is verplicht")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Auteur is verplicht")]
        [Display(Name = "Auteur")]
        public int AuteurId { get; set; }
        public List<Auteur>? Auteurs { get; set; }
    }
}
