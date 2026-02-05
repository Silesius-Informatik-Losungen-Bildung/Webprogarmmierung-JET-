using Microsoft.AspNetCore.Mvc;
using TrsWebApp.Models;

namespace TrsWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ContactInfoApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ContactInfoApi");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAll()
        {
            var contacts = await _httpClient.GetFromJsonAsync<List<ContactInfo>>("ContactInfo")
                   ?? new List<ContactInfo>();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> Get(int id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactInfo>($"ContactInfo/{id}");
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ContactInfo contact)
        {
            await _httpClient.PostAsJsonAsync("ContactInfo", contact);
            return Ok(new { message = "Contact wurde erstellt" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            await _httpClient.PutAsJsonAsync($"ContactInfo/{id}", contact);
            return Ok(new { message = "Contact wurde aktualisiert" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"ContactInfo/{id}");
            return Ok(new { message = "Contact wurde gelöscht" });
        }
    }
}
