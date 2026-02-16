using Ap12Web.Data;
using Ap12Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ap12Web.Controllers
{
    public class ProduktController : Controller
    {
        private Ap12WebDbContext _context;

        public ProduktController() {
            _context = new Ap12WebDbContext();
        }  
        
        [HttpGet]
        public IActionResult Erfassen(Produkt produkt)
        {
            produkt.HerstellerList = _context.Hersteller.ToList();
            return View(produkt);
        }

        [HttpPost]
        public IActionResult Speichern(Produkt produkt)
        {
            produkt.HerstellerList = _context.Hersteller.ToList();

            // Validiere nach Pflichteingaben
            if (!ModelState.IsValid)    // wenn Pflichteingaben nicht ausgefüllt sind, führe ich "Erfassen" aus
                return View("Erfassen", produkt);


            _context.Produkte.Add(produkt);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = produkt.ProduktId });

        }

        public IActionResult Details(int id)
        {
            var produkt = _context.Produkte.Include(p => p.Hersteller)
                .FirstOrDefault(p=> p.ProduktId == id);
            if (produkt == null)
                return NotFound();

            return View(produkt);
        }

        public IActionResult Liste()
        {
            var produkte = _context.Produkte.Include(p => p.Hersteller).ToList();
            return View(produkte);
        }
    }
}
