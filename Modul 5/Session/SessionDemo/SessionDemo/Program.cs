namespace SessionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // @@ADD Session-Services aktivieren
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Dauer der Session
                // Setzt das HttpOnly-Flag für das Cookie,
                // wodurch es nur vom Server aus zugänglich ist und nicht durch clientseitiges JavaScript.
                // Dies erhöht die Sicherheit gegen XSS-Angriffe.
                options.Cookie.HttpOnly = true;
                // Markiert das Cookie als "essenziell",
                // sodass es auch ohne ausdrückliche Zustimmung des Nutzers gesetzt wird
                // (z.B. für DSGVO-konforme Cookie-Banner).
                options.Cookie.IsEssential = true; 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // @@ADD Session aktivieren!

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
