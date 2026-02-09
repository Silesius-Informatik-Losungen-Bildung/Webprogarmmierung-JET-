using Ap12Web.Data;
using Ap12Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ap12Web.Controllers
{
    public class ProduktController : Controller
    {
        [HttpGet]
        public IActionResult Erfassen(Produkt? produkt)
        {
            return View(produkt);
        }

        [HttpPost]
        public IActionResult Speichern(Produkt produkt)
        {
            // Validiere nach Pflichteingaben
            if (!ModelState.IsValid)    // wenn Pflichteingaben nicht ausgefüllt sind, führe ich "Erfassen" aus
                return View("Erfassen", produkt);

			using Ap12WebDbContext dbcontext = new Ap12WebDbContext();
			dbcontext.Produkte.Add(produkt);
			dbcontext.SaveChanges();

			return RedirectToAction("Details", new { id = produkt.ProduktId });
        }

        public IActionResult Details(int id)
        {
			// Produkt mit id aus Db holen
			using Ap12WebDbContext dbcontext = new Ap12WebDbContext();
            var produkt = dbcontext.Produkte.Find(id);
            if (produkt == null)
                return NotFound();

            return View(produkt);
		}

        public IActionResult Liste()
        {
			using Ap12WebDbContext dbcontext = new Ap12WebDbContext();
            var produkte = dbcontext.Produkte.ToList();
            return View(produkte);
		}
    }
}
