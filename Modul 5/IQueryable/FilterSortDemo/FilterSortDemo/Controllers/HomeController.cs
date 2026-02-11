using System.Diagnostics;
using FilterSortDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilterSortDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(ProductListViewModel viewmodel)
        {
            // Ausgangspunkt: DbSet<T> liefert IQueryable<Product>
            // Es wird noch KEINE Datenbankabfrage ausgeführt
            IQueryable<Product> query = _dbContext.Products;

            // Optionale Filterung nach Suchbegriff
            // Die Where-Klausel wird zur Abfrage hinzugefügt,
            // aber noch nicht ausgeführt (Query Composing)
            if (!string.IsNullOrWhiteSpace(viewmodel.Search))
                query = query.Where(p => p.Name.Contains(viewmodel.Search));

            // Optionale Filterung nach Kategorie
            // Auch hier wird nur der Abfrageplan erweitert
            if (!string.IsNullOrWhiteSpace(viewmodel.Category))
                query = query.Where(p => p.Category == viewmodel.Category);

            // Dynamische Sortierung abhängig von der Benutzerauswahl
            // Es wird weiterhin nur die Abfrage beschrieben, nicht ausgeführt
            query = viewmodel.Sort switch
            {
                "name" => query.OrderBy(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),

                // Falls keine Sortierung gewählt wurde,
                // bleibt die Abfrage unverändert
                _ => query
            };

            // Materialisierung der Abfrage:
            // ERST HIER wird SQL erzeugt und an die Datenbank gesendet
            // Das Ergebnis liegt nun als List<Product> im Speicher vor
            viewmodel.Products = query.ToList();

            // Separate Abfrage für die Kategorienliste
            // AsNoTracking() verbessert die Performance,
            // da die Daten nur gelesen und nicht geändert werden
            viewmodel.Categories = _dbContext.Products
                .AsNoTracking()
                .Select(p => p.Category)
                .Distinct()
                .ToList();


            return View(viewmodel);
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
