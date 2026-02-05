using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TRSAP11V2.Data;
using TRSAP11V2.Logic;

namespace TrsWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var sqlServerInstanceName = Environment.GetEnvironmentVariable("SqlServerInstanceName", EnvironmentVariableTarget.User);
            builder.Services.AddDbContext<Trsap11v2Context>(options =>
                options.UseSqlServer(Config.ConfigItems.GetConnectionString("default")
                .Replace("@SqlServerInstanceName", sqlServerInstanceName)));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(options =>
            {
                // XML-Kommentare laden
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
