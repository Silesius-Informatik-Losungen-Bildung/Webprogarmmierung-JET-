using Microsoft.AspNetCore.Mvc;
using TrsWebApp.Models;
using TrsWebApp.Services;

namespace TrsWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoApiController : ControllerBase
    {
        private readonly ContactInfoService _service;

        public ContactInfoApiController(ContactInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAll()
        {
            var contacts = await _service.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> Get(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ContactInfo contact)
        {
            await _service.AddAsync(contact);
            return Ok(new { message = "Contact wurde erstellt" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            await _service.UpdateAsync(id, contact);
            return Ok(new { message = "Contact wurde aktualisiert" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Contact wurde gelöscht" });
        }
    }
}
