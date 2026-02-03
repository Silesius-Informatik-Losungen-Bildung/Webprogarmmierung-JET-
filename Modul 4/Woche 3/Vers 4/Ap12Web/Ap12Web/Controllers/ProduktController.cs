using Ap12Web.Data;
using Ap12Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ap12Web.Controllers
{
    public class ProduktController : Controller
    {
        [HttpGet]
        public IActionResult Erfassen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Speichern(Produkt produkt)
        {
            if (!ModelState.IsValid)
                return View("Erfassen", produkt);

            using Ap12WebDbContext dbContext = new Ap12WebDbContext();
            dbContext.Produkte.Add(produkt);
            dbContext.SaveChanges();

            return View();
            
        }
    }
}
