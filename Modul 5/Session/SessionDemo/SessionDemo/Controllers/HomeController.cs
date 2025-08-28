using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        private const string KeyNameBenutzername = "Benutzername";
        private const string KeyNameColors = "Colors";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Name = HttpContext.Session.GetString(KeyNameBenutzername) ?? string.Empty,
                Colors = HttpContext.Session.GetString(KeyNameColors) ?? "white"
            };
            return View(model);
        }

        public IActionResult Speichern(IndexViewModel viewModel)
        {
            if (viewModel.Name != null)
                HttpContext.Session.SetString(KeyNameBenutzername, viewModel.Name);
            if (viewModel.Colors != null)
                HttpContext.Session.SetString(KeyNameColors, viewModel.Colors);
            return RedirectToAction("Index");
        }
        public IActionResult Loeschen()
        {
            HttpContext.Session.Remove(KeyNameBenutzername);
            HttpContext.Session.Remove(KeyNameColors);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            var model = new IndexViewModel
            {
                Name = HttpContext.Session.GetString(KeyNameBenutzername) ?? string.Empty,
                Colors = HttpContext.Session.GetString(KeyNameColors) ?? "white"
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
