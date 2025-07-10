using System.Diagnostics;
using DateiUploadDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DateiUploadDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Hochladen(IFormFile datei)
        {
            if (datei != null && datei.Length > 0)
            {
                var pfad = Path.Combine("wwwroot/uploads", datei.FileName);

                var erweiterung = Path.GetExtension(datei.FileName).ToLower();
                Debug.WriteLine("Datei-Erweiterung:" + erweiterung);

                // Sicherstellen, dass der Ordner existiert
                Directory.CreateDirectory(Path.GetDirectoryName(pfad)!);

                using var stream = new FileStream(pfad, FileMode.Create);
                await datei.CopyToAsync(stream);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MultiHochladen(IEnumerable<IFormFile> dateien)
        {
            if (dateien != null)
                foreach (var datei in dateien)
                {
                    if (datei != null && datei.Length > 0)
                    {
                        var pfad = Path.Combine("wwwroot/uploads", datei.FileName);
                        var erweiterung = Path.GetExtension(datei.FileName).ToLower();
                        Debug.WriteLine("Datei-Erweiterung:" + erweiterung);

                        // Sicherstellen, dass der Ordner existiert
                        Directory.CreateDirectory(Path.GetDirectoryName(pfad)!);

                        // Beispiel Umwandlung in ByTe-Array (z.B. f.d. Speicherung in DB)
                        using var ms = new MemoryStream();
                        await datei.CopyToAsync(ms);
                        var byteArray = ms.ToArray();

                        // Speicherung auf HDD
                        using var stream = new FileStream(pfad, FileMode.Create);
                        await datei.CopyToAsync(stream);
                    }

                }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
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
