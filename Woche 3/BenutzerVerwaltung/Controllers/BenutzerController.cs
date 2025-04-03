using BenutzerVerwaltung.Data;
using BenutzerVerwaltung.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/benutzer")]
public class BenutzerController : ControllerBase
{

    [HttpPost("registrieren")]
    public IActionResult Registrieren([FromForm] Benutzer benutzer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        BenutzerData.BenutzerListe.Add(benutzer);
        return Ok("Registrierung von Benutzer " + benutzer.Nachname + " erfolgreich.");
    }
}