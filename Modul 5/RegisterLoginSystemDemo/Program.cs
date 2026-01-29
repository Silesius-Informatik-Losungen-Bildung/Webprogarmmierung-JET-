using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegisterLoginSystemDemo.Data;
using RegisterLoginSystemDemo.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var sqlServerInstanceName = Environment.GetEnvironmentVariable("SqlServerInstanceName", EnvironmentVariableTarget.User);
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
             .Replace("@SqlServerInstanceName", sqlServerInstanceName)));

        builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", options =>
            {
                options.LoginPath = "/Account/Login";
            });

        builder.Services.AddAuthorization();
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IPasswordHasher<Benutzer>, PasswordHasher<Benutzer>>();
        
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();

        app.Run();
    }
}