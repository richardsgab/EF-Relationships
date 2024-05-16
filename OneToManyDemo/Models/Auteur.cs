using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models
{
	public class Auteur
	{
		public int AuteurId { get; set; }
		[Required]
		[StringLength(50)]
		public string Naam { get; set; }
        public ICollection<Boek> Boeken { get; set; }//indica la relacion One to many
    }
}
