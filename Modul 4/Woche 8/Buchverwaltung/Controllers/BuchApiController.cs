using Buchverwaltung.Data;
using Buchverwaltung.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buchverwaltung.Controllers
{
    [ApiController]
    [Route("api/buecher")]
    public class BuchApiController : Controller
    {
        [HttpPost]
        public IActionResult Hinzufuegen([FromBody] Buch buch)
        {
            buch.Id = BuchData.Buecher.Count + 1;
            BuchData.Buecher.Add(buch);
            return Ok($"Buch hinzugefügt: {buch.Titel} von {buch.Autor}");
        }

        [HttpGet("{id}")]
        public IActionResult GetBuch([FromRoute] int id)
        {
            var buch = BuchData.Buecher.FirstOrDefault(b => b.Id == id);
            return buch != null ? Ok(buch) : NotFound("Buch nicht gefunden");
        }


        [HttpGet]
        public IActionResult GetBuecher()
        {
            return Ok(BuchData.Buecher);
        }
    }
}
