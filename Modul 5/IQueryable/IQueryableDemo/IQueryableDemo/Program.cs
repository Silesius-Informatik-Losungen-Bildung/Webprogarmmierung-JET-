
using Microsoft.EntityFrameworkCore;

namespace IQueryableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new KundenDbContext();
            context.Database.EnsureCreated();

            // Immer noch keine Datenbankabfrage
            var kunden1 = context.Kunden
            .Where(k => k.Land == "AT")
            .OrderBy(k => k.Name);


            // Durch ToList(): Datenbankabfrage
            var kunden2 = context.Kunden
                .Where(k => k.Land == "DE")
                .OrderBy(k => k.Name)
                .ToList();


            // Auslösende Methoden: - ToList() - First(), FirstOrDefault() - Single(), Count() - foreach
            var liste = kunden2.ToList(); // SQL wird hier ausgeführt
            Console.WriteLine("Kunden aus Deutschland (sortiert nach Name):\n");

            foreach (var kunde in kunden2)
            {
                Console.WriteLine($"{kunde.Name} ({kunde.Land})");
            }


           // Beispiel Gegenüberstellung:
            context.Kunden.Where(k => k.Land == "AT"); // IQueryable
            context.Kunden.ToList().Where(k => k.Land == "AT"); // IEnumerable


            // Aufgabe: Markieren Sie, ob die FILTERUNG in SQL oder in C# erfolgt.
            
            // A
            context.Kunden.Where(k => k.Name.StartsWith("A")).ToList();

            // B
            context.Kunden.ToList().Where(k => k.Name.StartsWith("A"));


            //Fehler 1: Zu frühes ToList()
            var kunden3 = context.Kunden.ToList(); // Zu frühes ToList()
            var gefiltert = kunden3.Where(k => k.Land == "AT");



            //Materialisierung erst am Rand der Anwendung
            //Beispiel:

            var kunden4 = context.Kunden
                .Where(k => k.Land == "AT")
                .Select(k => new { k.Name, k.Land })
                .ToList();


            //Aufgabe: Formulieren Sie eine EF-Core - Abfrage: -Nur Kunden aus Österreich - Sortiert nach Name -Ausgabe als Liste
            //Musterlösung:
            var kunden = context.Kunden
                .Where(k => k.Land == "AT")
                .OrderBy(k => k.Name)
                .ToList();




            Console.WriteLine("\n--- Ende ---");
            Console.ReadKey();
        }
    }

    class KundenDbContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("KundenDemoDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunde>().HasData(
                new Kunde { KundeId = 1, Name = "Müller", Land = "DE" },
                new Kunde { KundeId = 2, Name = "Schmidt", Land = "DE" },
                new Kunde { KundeId = 3, Name = "Huber", Land = "AT" },
                new Kunde { KundeId = 4, Name = "Meier", Land = "DE" },
                new Kunde { KundeId = 5, Name = "Rossi", Land = "IT" }
            );
        }
    }

    class Kunde
    {
        public int KundeId { get; set; }
        public string Name { get; set; }
        public string Land { get; set; }
    }
}
