using Ap12Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Ap12Web.Data
{
    public class Ap12WebDbContext : DbContext
    {
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Hersteller> Hersteller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Ap12Web;Data Source=localhost\\SQLEXPRESS;TrustServerCertificate=true");
        }
    }
}
