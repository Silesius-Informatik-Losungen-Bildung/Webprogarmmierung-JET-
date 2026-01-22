using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewmodel = new IndexViewModel()
            {
                Name = HttpContext.Session.GetString("Name") ?? string.Empty,
                Colors = HttpContext.Session.GetString("Colors") ?? "white"
            };     
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Speichern(IndexViewModel viewModel)
        {
            // In Session speichern
            if (viewModel.Name != null)
                HttpContext.Session.SetString("Name", viewModel.Name);
            
            if (viewModel.Colors != null)
                HttpContext.Session.SetString("Colors", viewModel.Colors);

            return RedirectToAction("Index");
        }

        public IActionResult Loeschen()
        {
            HttpContext.Session.Remove("Name");
            HttpContext.Session.Remove("Colors");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            var viewmodel = new BasisViewModel()
            {
                Name = HttpContext.Session.GetString("Name") ?? string.Empty,
                Colors = HttpContext.Session.GetString("Colors") ?? "white"
            };

            return View(viewmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
