using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SerilogDemo.Models;

namespace SerilogDemo.Controllers
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
            _logger.LogInformation("Home/Index aufgerufen");
            return View();
        }

        public IActionResult OkDemo()
        {
            _logger.LogInformation("Dies ist eine Info-Lognachricht aus MVC");
            return Content("Alles ok – Nachricht geloggt!");
        }

        public IActionResult ErrorDemo()
        {
            try
            {
                throw new Exception("Testfehler in MVC!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Es ist ein Fehler im ErrorDemo passiert");
                return Content("Fehler wurde geloggt!");
            }
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
