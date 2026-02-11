
public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Products.Any()) return;

        db.Products.AddRange(
            new Product { Name = "Laptop", Category = "Elektronik", Price = 999 },
            new Product { Name = "Maus", Category = "Elektronik", Price = 25 },
            new Product { Name = "Tisch", Category = "Möbel", Price = 199 },
            new Product { Name = "Stuhl", Category = "Möbel", Price = 89 },
            new Product { Name = "Kaffee", Category = "Lebensmittel", Price = 6 }
        );

        db.SaveChanges();
    }
}
