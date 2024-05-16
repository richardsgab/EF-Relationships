using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Models;

namespace OneToManyDemo.Data
{
	public class SeedData
	{
		public static void AddRecords(ModelBuilder modelBuilder)
		{
			//seeding data
			modelBuilder.Entity<Auteur>().HasData(
					new Auteur { AuteurId = 1, Naam = "Isabel Allende" },
					new Auteur { AuteurId = 2, Naam = "Stephen King" },
					new Auteur { AuteurId = 3, Naam = "J.K. Rowling" },
					new Auteur { AuteurId = 4, Naam = "G.Garcia Marquez" }
					);
			modelBuilder.Entity<Boek>().HasData(
				new Boek { BoekId = 1, Titel = "Eva Luna", AuteurId = 1, },
				new Boek { BoekId = 2, Titel = "La casa de los Espiritus", AuteurId = 1 },
				new Boek { BoekId = 3, Titel = "Horror book", AuteurId = 2, },
				new Boek { BoekId = 4, Titel = "Harry Potter 1", AuteurId = 3, },
				new Boek { BoekId = 5, Titel = "Goragora", AuteurId = 4, },
				new Boek { BoekId = 6, Titel = "Horror book2", AuteurId = 2 },
				new Boek { BoekId = 7, Titel = "Harry Potter and friends", AuteurId = 3 },
				new Boek { BoekId = 8, Titel = "Harry Potter and enemies", AuteurId = 3 }
				);

		}
	}
}
