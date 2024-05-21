using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Data;
using OneToManyDemo.Models;
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

		public async Task<IActionResult> Filters(int? GeselecteerdeAuteurId)
		{
			var auteurs = await _context.Auteurs.ToListAsync();

			IQueryable<Boek> boekenQuery = _context.Boeks.Include(b => b.Auteur);

			if (GeselecteerdeAuteurId.HasValue)
			{
				boekenQuery = boekenQuery.Where(b => b.AuteurId == GeselecteerdeAuteurId);
			}

			var boeken = await boekenQuery.ToListAsync();

			var boekenViewModel = boeken.Select(b => new BoekAuteurViewModel
			{
				BoekId = b.BoekId,
				Titel = b.Titel,
				AuteurNaam = b.Auteur.Naam
			}).ToList();

			var filtersViewModel = new BoekenViewModel
			{
				Auteurs = auteurs,
				Boeken = boekenViewModel,
				GeselecteerdeAuteurId = GeselecteerdeAuteurId ?? 0
			};
			return View(filtersViewModel);
		}

		public async Task<IActionResult> Filter1(int? GeselecteerdeAuteurId)
		{
			var auteurs = await _context.Auteurs.ToListAsync();
			IQueryable<Boek> boekenQuery = _context.Boeks.Include(b => b.Auteur);

			if(GeselecteerdeAuteurId.HasValue && GeselecteerdeAuteurId > 0)
			{
				boekenQuery = boekenQuery.Where(b => b.AuteurId == GeselecteerdeAuteurId.Value);	
			}

			var boeken = await boekenQuery.ToListAsync();
			var viewModel = new BoekenVM1
			{
				Auteurs = auteurs,
				Boeken = boeken,
				GeselecteerdeAuteurId = GeselecteerdeAuteurId ?? 0
			};

			return View(viewModel);
		}

		public async Task<IActionResult> Create()
		{
			//buscar el autor en la lista del dropdown gracias al ViewModel CreateBoekVM
			var auteurs = await _context.Auteurs.ToListAsync();
			var viewmodel = new CreateBoekViewModel
			{
				Auteurs = auteurs
			};
			return View(viewmodel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateBoekViewModel viewmodel)
		{
			if (!ModelState.IsValid) 
			{
				viewmodel.Auteurs = await _context.Auteurs.ToListAsync();
				return View(viewmodel);
			}
			var newBoek = new Boek
			{
				Titel = viewmodel.Titel,
				AuteurId = viewmodel.AuteurId,
			};
			_context.Boeks.Add(newBoek);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Filters));
		}
		public async Task<IActionResult> Details(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}
			var boek = await _context.Boeks
				.Include(b => b.Auteur)
				.FirstOrDefaultAsync(b => b.BoekId == id);
			if (boek == null)
			{
				return NotFound();
			}
			return View(boek);
		}
	}
}
