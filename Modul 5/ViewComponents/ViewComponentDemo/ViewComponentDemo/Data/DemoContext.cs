using Microsoft.EntityFrameworkCore;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }

        public DbSet<Artikel> Artikel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artikel>().HasData(
                new Artikel { Id = 1, Titel = "Erster Artikel", ErstelltAm = DateTime.Now.AddDays(-2) },
                new Artikel { Id = 2, Titel = "Zweiter Artikel", ErstelltAm = DateTime.Now.AddDays(-1) },
                new Artikel { Id = 3, Titel = "Dritter Artikel", ErstelltAm = DateTime.Now },
                new Artikel { Id = 4, Titel = "Vierter Artikel", ErstelltAm = DateTime.Now }
            );
        }
    }
}
