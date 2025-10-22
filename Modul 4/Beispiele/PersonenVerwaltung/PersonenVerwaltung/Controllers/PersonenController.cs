using Microsoft.AspNetCore.Mvc;
using PersonenVerwaltung.Data;
using PersonenVerwaltung.Models;

namespace PersonenVerwaltung.Controllers
{
    public class PersonenController : Controller
    {

        [HttpGet]
        public IActionResult Registrieren()
        {
            var person = new Person();
            return View(person);
        }

        [HttpPost]
        public IActionResult Registrieren(Person person)
        {
            if (!ModelState.IsValid)
                return View(person);

            using PersonenDbContext perssonenDbContext = new PersonenDbContext();
            perssonenDbContext.Personen.Add(person);
            perssonenDbContext.SaveChanges();

            return RedirectToAction("Details", new { id = person.PersonId });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using PersonenDbContext perssonenDbContext = new PersonenDbContext();
            var person = perssonenDbContext.Personen.Where(p => p.PersonId == id).FirstOrDefault();
            return View(person);
        }
    }
}
