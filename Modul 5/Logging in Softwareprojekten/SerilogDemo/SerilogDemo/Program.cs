using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace SerilogDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serilog konfigurieren
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console() // Console
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) 
                .WriteTo.MSSqlServer( // SQL Server
                    connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        AutoCreateSqlTable = true
                    })
                .CreateLogger();

            builder.Host.UseSerilog(); // Serilog statt Default-Logger


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
