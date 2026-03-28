using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mikroservisna.Data;
using Mikroservisna.Domain;
using Mikroservisna.Models.Dogadjaj;
using Mikroservisna.Models.Lokacija;

namespace Mikroservisna.Controllers
{
    public class DogadjajController : Controller
    {
        private readonly FonDbContext _context;

        public DogadjajController(FonDbContext context)
        {
            _context = context;
        }
        public  IActionResult Index()
        {
            var dogadjajiIzBaze = _context.Dogadjaji
        .Include(x => x.Lokacija)
        .ToList();


            var viewModels = dogadjajiIzBaze.Select(x => new DogadjajViewModel()
            {
                Id = x.Id,
                Naziv = x.Naziv, 
                Agenda = x.Agenda, 
                DatumOdrazavanja = x.DatumOdrazavanja, 
                Trajanje = x.Trajanje, 
                Cena = x.Cena, 


                IdLokacija = x.IdLokacija, 
                Lokacija = x.Lokacija
            }).ToList();

        
            return View(viewModels);
        }
        public IActionResult Create()
        {
            
            var lokacije = _context.Lokacije.ToList();
            ViewBag.Lokacije = lokacije;
            ViewBag.Predavaci = _context.Predavaci.ToList();
    
            return View(new DogadjajViewModel());
        }

        [HttpPost]
        public IActionResult Create(DogadjajViewModel viewModel, int[] izabraniPredavaciId)
        {
            var postojecaLokacija = _context.Lokacije.Find(viewModel.IdLokacija);
            var dogadjaj = new Dogadjaj()
            {
                Naziv = viewModel.Naziv,
                Agenda = viewModel.Agenda,
                DatumOdrazavanja = viewModel.DatumOdrazavanja,
                Trajanje = viewModel.Trajanje,
                Cena = viewModel.Cena,
                IdLokacija = viewModel.IdLokacija,
                Lokacija = postojecaLokacija,
                Predavaci = new List<Predavac>() 
            };

            
            if (izabraniPredavaciId != null)
            {
                foreach (var id in izabraniPredavaciId)
                {
                    var predavac = _context.Predavaci.Find(id);
                    if (predavac != null)
                    {
                        dogadjaj.Predavaci.Add(predavac);
                    }
                }
            
        }

        _context.Dogadjaji.Add(dogadjaj);
    _context.SaveChanges();

    return RedirectToAction("Index");
    }
    }

    
}
