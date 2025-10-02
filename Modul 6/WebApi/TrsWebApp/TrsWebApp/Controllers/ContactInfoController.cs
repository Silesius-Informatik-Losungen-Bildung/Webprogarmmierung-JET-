using Microsoft.AspNetCore.Mvc;
using TrsWebApp.Models;
using TrsWebApp.Services;

namespace TrsWebApp.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly ContactInfoService _service;

        public ContactInfoController(ContactInfoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _service.GetAllAsync();
            return View(contacts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var contact = await _service.GetByIdAsync(id);
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

            await _service.AddAsync(contact);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactInfo contact)
        {
            if (!ModelState.IsValid) return View(contact);

            await _service.UpdateAsync(contact.ContactInfoId, contact);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int contactInfoId)
        {
            await _service.DeleteAsync(contactInfoId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Spa()
        {
            return View();
        }

    }
}
