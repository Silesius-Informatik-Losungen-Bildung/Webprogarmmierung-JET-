using Microsoft.EntityFrameworkCore;
using PersonenVerwaltung.Models;

namespace PersonenVerwaltung.Data;

public partial class PersonenDbContext : DbContext
{
    public virtual DbSet<Person> Personen { get; set; }
    public virtual DbSet<Standort> Standorte { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PersonenVerwaltung;Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;TrustServerCertificate=true");

}
