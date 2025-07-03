using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        private const string KeyName = "Benutzername";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString(KeyName);
            return View("Index", name);
        }

        public IActionResult Speichern(string? name)
        {
            if (name != null)
                HttpContext.Session.SetString(KeyName, name);
            return RedirectToAction("Index");
        }
        public IActionResult Loeschen()
        {
            HttpContext.Session.Remove(KeyName);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
