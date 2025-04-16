using Buchverwaltung.Data;
using Buchverwaltung.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buchverwaltung.Controllers
{
    public class BuchController : Controller
    {
        [HttpGet]
        public IActionResult Erfassen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Erfassen(Buch buch)
        {
            if (ModelState.IsValid)
            {
                buch.Id = BuchData.Buecher.Count + 1;
                BuchData.Buecher.Add(buch);
                return RedirectToAction("Liste");
            }
            return View(buch);
        }

        [HttpGet]
        public IActionResult Liste()
        {
            return View(BuchData.Buecher);
        }
    }
}
