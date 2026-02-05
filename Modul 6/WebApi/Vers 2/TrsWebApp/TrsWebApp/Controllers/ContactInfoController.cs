using Microsoft.AspNetCore.Mvc;
using TrsWebApp.Models;

namespace TrsWebApp.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ContactInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ContactInfoApi");
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _httpClient.GetFromJsonAsync<List<ContactInfo>>("ContactInfo")
                ?? new List<ContactInfo>();
            return View(contacts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactInfo>($"ContactInfo/{id}");
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            if (!ModelState.IsValid) return View(contact);

            await _httpClient.PostAsJsonAsync("ContactInfo", contact);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactInfo>($"ContactInfo/{id}");
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactInfo contact)
        {
            if (!ModelState.IsValid) return View(contact);

            await _httpClient.PutAsJsonAsync($"ContactInfo/{contact.ContactInfoId}", contact);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _httpClient.GetFromJsonAsync<ContactInfo>($"ContactInfo/{id}");
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int contactInfoId)
        {
            await _httpClient.DeleteAsync($"ContactInfo/{contactInfoId}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Spa()
        {
            return View();
        }

    }
}
