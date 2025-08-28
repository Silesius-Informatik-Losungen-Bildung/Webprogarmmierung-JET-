using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PartialViewDemo.Models;

namespace PartialViewDemo.Controllers
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
            var produkte = new List<Produkt>
            {
                new Produkt { Name = "Apfel", Preis = 1.20m },
                new Produkt { Name = "Banane", Preis = 0.80m },
                new Produkt { Name = "Kirsche", Preis = 2.50m }
            };

            return View(produkte);
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
