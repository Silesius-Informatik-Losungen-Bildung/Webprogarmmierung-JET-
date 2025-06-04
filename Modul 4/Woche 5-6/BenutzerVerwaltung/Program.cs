namespace BenutzerVerwaltung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints?.MapControllers();
            });

            app.Run();
        }
    }
}
