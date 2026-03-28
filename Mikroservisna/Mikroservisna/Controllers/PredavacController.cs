using Microsoft.AspNetCore.Mvc;

namespace Mikroservisna.Controllers
{
    using global::Mikroservisna.Data;
    using global::Mikroservisna.Domain;
    using global::Mikroservisna.Models.Predavac;
    using Microsoft.AspNetCore.Mvc;
    

    namespace Mikroservisna.Controllers
    {
        public class PredavacController : Controller
        {
            private readonly FonDbContext _context;

            public PredavacController(FonDbContext context)
            {
                _context = context;
            }

           
            public IActionResult Index()
            {
                var predavaci = _context.Predavaci.Select(p => new PredavacViewModel
                {
                    Id = p.Id,
                    Ime = p.Ime, 
                    Prezime = p.Prezime,
                    Titula = p.Titula,
                    Oblast = p.Oblast
                }).ToList();

                return View(predavaci);
            }

        
            public IActionResult Create()
            {
                return View(new PredavacViewModel());
            }

           
            [HttpPost]
            public IActionResult Create(PredavacViewModel vm)
            {
                var noviPredavac = new Predavac
                {
                    Ime = vm.Ime,
                    Prezime = vm.Prezime,
                    Titula = vm.Titula,
                    Oblast = vm.Oblast
                };

                _context.Predavaci.Add(noviPredavac);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
