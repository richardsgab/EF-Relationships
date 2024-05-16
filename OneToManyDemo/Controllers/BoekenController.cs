using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Data;
using OneToManyDemo.Models.ViewModels;

namespace OneToManyDemo.Controllers
{
	public class BoekenController : Controller
	{
		readonly BoekenDBContext _context;
        public BoekenController(BoekenDBContext dBContext)
        {
            _context = dBContext;
        }
        public async Task<IActionResult> Index()//Para mostrar el contenido de la DB
		{
			var boekAuteurViewModel = _context.Boeks
				.Include(b => b.Auteur)
				.Select(b => new BoekAuteurViewModel
				{
					BoekId = b.BoekId,
					Titel = b.Titel,
					AuteurNaam = b.Auteur.Naam,
				});
			return View(boekAuteurViewModel);
		}
	}
}
