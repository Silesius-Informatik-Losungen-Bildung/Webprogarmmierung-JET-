using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRSAP11V2.Data;
using TRSAP11V2.Models;

namespace TrsWebApi.Controllers
{
    /// <summary>
    /// API-Controller für die Verwaltung von Kontaktinformationen.
    /// Bietet CRUD-Operationen für <see cref="ContactInfo"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ContactInfoController : ControllerBase
    {
        private readonly Trsap11v2Context _context;

        /// <summary>
        /// Erstellt eine neue Instanz des <see cref="ContactInfoController"/>.
        /// </summary>
        /// <param name="context">Der Datenbankkontext für das TableReservationSystem.</param>
        public ContactInfoController(Trsap11v2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Fügt eine neue <see cref="ContactInfo"/> in die Datenbank ein.
        /// </summary>
        /// <param name="contactInfo">Das hinzuzufügende Kontaktobjekt.</param>
        /// <returns>Die erstellte <see cref="ContactInfo"/> mit Statuscode 201 (Created).</returns>
        [HttpPost]
        public async Task<ActionResult<ContactInfo>> Add([FromBody] ContactInfo contactInfo)
        {
            await _context.ContactInfos.AddAsync(contactInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Add),
                new { id = contactInfo.ContactInfoId },
                contactInfo
            );
        }

        /// <summary>
        /// Gibt alle gespeicherten <see cref="ContactInfo"/>-Einträge zurück.
        /// </summary>
        /// <returns>Eine Liste aller Kontaktinformationen.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ContactInfo>>> Get()
        {
            var contacts = await _context.ContactInfos.ToListAsync();
            return Ok(contacts);
        }

        /// <summary>
        /// Löscht eine <see cref="ContactInfo"/> anhand der ID.
        /// </summary>
        /// <param name="id">Die ID des zu löschenden Kontakts.</param>
        /// <returns>NoContent (204), falls erfolgreich, sonst NotFound (404).</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
                return NotFound();

            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Aktualisiert eine bestehende <see cref="ContactInfo"/>.
        /// </summary>
        /// <param name="id">Die ID des zu aktualisierenden Kontakts.</param>
        /// <param name="contactInfo">Das neue Kontaktobjekt mit aktualisierten Werten.</param>
        /// <returns>NoContent (204), falls erfolgreich, sonst NotFound (404).</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contactInfo)
        {
            var exists = await _context.ContactInfos.FindAsync(id);
            if (exists == null)
                return NotFound();

            _context.Entry(exists).CurrentValues.SetValues(contactInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Gibt eine einzelne <see cref="ContactInfo"/> anhand der ID zurück.
        /// </summary>
        /// <param name="id">Die ID des gesuchten Kontakts.</param>
        /// <returns>Das gefundene <see cref="ContactInfo"/>-Objekt oder NotFound (404).</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> Get(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
                return NotFound();

            return Ok(contactInfo);
        }
    }
}
