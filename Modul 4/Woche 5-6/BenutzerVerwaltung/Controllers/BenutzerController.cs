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
        return Ok($"Registrierung erfolgreich: {benutzer.Vorname} {benutzer.Nachname}, Alter: {benutzer.Alter}");
    }

    [HttpPost("registrieren-json")]
    public IActionResult RegistrierenJson([FromBody] Benutzer benutzer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        BenutzerData.BenutzerListe.Add(benutzer);
        return Ok($"Registrierung erfolgreich: {benutzer.Vorname} {benutzer.Nachname}, Alter: {benutzer.Alter}");
    }

    [HttpGet("{nachname}")]
    public IActionResult GetBenutzer([FromRoute] string nachname)
    {
        var benutzer = BenutzerData.BenutzerListe.FirstOrDefault(b => b.Nachname == nachname);
        return benutzer != null ? Ok(benutzer) : NotFound("Benutzer nicht gefunden");
    }

    [HttpGet("liste")]
    public IActionResult GetAlleBenutzer()
    {
        return Ok(BenutzerData.BenutzerListe);
    }
}