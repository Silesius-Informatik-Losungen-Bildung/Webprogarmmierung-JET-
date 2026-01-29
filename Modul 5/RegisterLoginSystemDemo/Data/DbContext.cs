using Microsoft.EntityFrameworkCore;
using RegisterLoginSystemDemo.Models;

namespace RegisterLoginSystemDemo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Benutzer> Benutzer { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benutzer>(entity =>
            {
                entity.HasKey(e => e.BenutzerId);
                entity.Property(e => e.BenutzerId).UseIdentityColumn(1, 1);
                entity.Property(e => e.Benutzername).HasMaxLength(30);
                entity.Property(e => e.PasswortHash).HasMaxLength(100);
                entity.Property(e => e.Rolle).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(30);
            });
        }
    }
}
