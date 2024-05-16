using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models.ViewModels
{
	public class BoekAuteurViewModel
	{
		[Key]
        public int BoekId { get; set; }
		public string Titel { get; set;}
		[Display(Name = "Autor")]
		public string AuteurNaam { get; set;}
    }
}
