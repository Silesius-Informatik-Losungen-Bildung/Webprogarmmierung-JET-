using ChartServerseitigDemo.Data;
using Microsoft.AspNetCore.Mvc;
using ScottPlot;

namespace ChartServerseitigDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UmsatzDbContext _dbContext;

        public HomeController(UmsatzDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChartImage()
        {
            // Alle Umsätze aus der Datenbank laden
            // ToList() sorgt dafür, dass die Abfrage sofort ausgeführt wird
            // und die Daten als Liste im Speicher vorliegen.
            var daten = _dbContext.Umsaetze.ToList();

            // Neues Plot-Objekt erstellen (z.B. mit ScottPlot)
            var plot = new Plot();

            // Entfernt den unteren Randabstand der X-Achse
            // Dadurch beginnt der Plot direkt bei 0 ohne zusätzlichen Abstand
            plot.Axes.Margins(bottom: 0);

            // Titel des Diagramms setzen
            plot.Title("Umsatz je Monat");

            // Beschriftung der Y-Achse (Betrag in Euro)
            plot.YLabel("EUR");

            // Beschriftung der X-Achse (Monate)
            plot.XLabel("Monat");

            // X-Werte definieren (Monate 1–12)
            // Diese stehen für Januar bis Dezember
            double[] dataX = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            // Y-Werte aus den Datenbankeinträgen erzeugen
            // Jeder Umsatzbetrag wird in double konvertiert
            // Select projiziert nur die Eigenschaft "Betrag"
            double[] dataY = daten
                .Select(u => (double)u.Betrag)
                .ToArray();

            // Fügt dem Plot eine Scatter-Kurve hinzu
            // dataX = Monate
            // dataY = Umsatzwerte
            plot.Add.Scatter(dataX, dataY);

            // Bild aus dem Plot generieren (600x400 Pixel)
            Image img = plot.GetImage(width: 600, height: 400);

            // Bild als PNG-Datei zurückgeben (z.B. in einem ASP.NET Controller)
            // File(...) erzeugt ein HTTP-Response mit Content-Type "image/png"
            return File(img.GetImageBytes(), "image/png");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
