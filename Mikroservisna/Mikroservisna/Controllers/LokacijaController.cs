using Microsoft.AspNetCore.Mvc;
using Mikroservisna.Data;
using Mikroservisna.Domain;
using Mikroservisna.Models.Lokacija; 

namespace Mikroservisna.Controllers
{
    public class LokacijaController : Controller
    {
        private readonly FonDbContext _context;

        public LokacijaController(FonDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View(new LokacijaViewModel());
        }

        [HttpPost]
        public IActionResult Create(LokacijaViewModel viewModel)
        {
            var lokacija = new Lokacija()
            {
                Naziv = viewModel.Naziv,
                Adresa = viewModel.Adresa,
                Kapacitet = viewModel.Kapacitet
            };

            _context.Lokacije.Add(lokacija);
            _context.SaveChanges();

            
            return RedirectToAction("Create", "Dogadjaj");
        }
    }
}
