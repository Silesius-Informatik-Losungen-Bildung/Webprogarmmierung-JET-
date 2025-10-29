using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonenVerwaltung.Data;
using PersonenVerwaltung.Models;
using PersonenVerwaltung.Viewmodels;

namespace PersonenVerwaltung.Controllers
{
    public class PersonenController : Controller
    {

        [HttpGet]
        public IActionResult Registrieren()
        {
            return View(new RegistrierenViewmodel());
        }


        [HttpGet]
        public IActionResult Liste()
        {
            using PersonenDbContext personenDbContext = new PersonenDbContext();
            var personen = personenDbContext.Personen.Include(p => p.Standort).ToList();

            var personenListeViewmodel = new PersonenListeViewmodel();
            personenListeViewmodel.Items = new List<PersonDetailsViewmodel>();

            foreach (var p in personen)
            {
                var personDetailsViewmodel = new PersonDetailsViewmodel()
                {
                    PersonId = p.PersonId.ToString(),
                    Standort = p.Standort.Name,
                    VornameNachname = p.Vorname + " " + p.Nachname
                };
                personenListeViewmodel.Items.Add(personDetailsViewmodel);
            }
            return View(personenListeViewmodel);
        }

        [HttpPost]
        public IActionResult Registrieren(RegistrierenViewmodel registrierenViewmodel)
        {
            if (!ModelState.IsValid)
                return View(registrierenViewmodel);

            var person = new Person()
            {
                Alter = registrierenViewmodel.Alter,
                Nachname = registrierenViewmodel.Nachname,
                StandortId = registrierenViewmodel.StandortId,
                Vorname = registrierenViewmodel.Vorname
            };


            using PersonenDbContext perssonenDbContext = new PersonenDbContext();
            perssonenDbContext.Personen.Add(person);
            perssonenDbContext.SaveChanges();

            return RedirectToAction("Details", new { personId = person.PersonId });
        }

        [HttpGet]
        public IActionResult Details(int personId)
        {
            using PersonenDbContext perssonenDbContext = new PersonenDbContext();
            var person = perssonenDbContext.Personen
                .Include(p => p.Standort)
                .Where(p => p.PersonId == personId).FirstOrDefault();

            var detailsViewmodel = new DetailsViewmodel();
            if (person == null)
                return View(detailsViewmodel);

            detailsViewmodel.Vorname = person.Vorname;
            detailsViewmodel.Nachname = person.Nachname;
            detailsViewmodel.Alter = person.Alter;
            detailsViewmodel.Standort = person.Standort.Name;

            return View(detailsViewmodel);
        }
    }
}
