using Microsoft.EntityFrameworkCore;

namespace OneToManyDemo.Models.ViewModels
{
	[Keyless]
	public class BoekenViewModel
	{
		public List<BoekAuteurViewModel> Boeken { get; set; }
		public List<Auteur> Auteurs { get; set; }
		public int GeselecteerdeAuteurId { get; set; }
		
	}
}
