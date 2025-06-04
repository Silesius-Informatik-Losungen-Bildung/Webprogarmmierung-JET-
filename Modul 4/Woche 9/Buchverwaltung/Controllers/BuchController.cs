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

                // Anlegen
                if (!buch.Id.HasValue)
                {
                    buch.Id = BuchData.Buecher.Count + 1;
                    BuchData.Buecher.Add(buch);
                    return RedirectToAction("Liste");
                }


                // Bearbeiten
                var vorhandenesBuch = BuchData.Buecher.FirstOrDefault(b => b.Id == buch.Id);
                if (vorhandenesBuch == null)
                    return NotFound();

                vorhandenesBuch.Titel = buch.Titel;
                vorhandenesBuch.ISBN = buch.ISBN;
                vorhandenesBuch.Autor = buch.Autor;
                vorhandenesBuch.Erscheinungsjahr = buch.Erscheinungsjahr;

                return RedirectToAction("Liste");
            }
            return View(buch);
        }

        [HttpGet]
        public IActionResult Liste()
        {
            return View(BuchData.Buecher);
        }


        [HttpGet]
        public IActionResult Bearbeiten(int id)
        {
            var buch = BuchData.Buecher.FirstOrDefault(b => b.Id == id);
            if (buch == null)
                return NotFound();

            return View("Erfassen", buch);
        }

        [HttpGet]
        public IActionResult Loeschen(int id)
        {
            var buch = BuchData.Buecher.FirstOrDefault(b => b.Id == id);
            if (buch == null)
                return NotFound();

            BuchData.Buecher.Remove(buch);
            return RedirectToAction("Liste");
        }

        [HttpGet]
        public IActionResult AlleLoeschen()
        {
            BuchData.Buecher.Clear();
            return RedirectToAction("Liste");
        }

        [HttpGet]
        public IActionResult UpdateSelected([FromRoute] int id, bool isSelected)
        {
            var buch = BuchData.Buecher.FirstOrDefault(b => b.Id == id);
            if (buch == null)
                return NotFound();

            buch.IsSelected = isSelected;

            return Ok();
        }

        [HttpGet]
        public IActionResult DeleteSelected(ICollection<int> ids)
        {
            if (ids != null)
                BuchData.Buecher.RemoveAll(b => ids.Contains(b.Id.Value));

            return RedirectToAction("Liste");
        }
    }
}
