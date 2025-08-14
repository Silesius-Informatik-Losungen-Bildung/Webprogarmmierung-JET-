using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegisterLoginSystemDemo.Data;
using RegisterLoginSystemDemo.Models;
using System;

namespace RegisterLoginSystemDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var sqlServerInstanceName = Environment.GetEnvironmentVariable("SqlServerInstanceName", EnvironmentVariableTarget.User);
            builder.Services.AddDbContext<RegisterLoginDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                 .Replace("@SqlServerInstanceName", sqlServerInstanceName)));


                builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/Login";
                });

                builder.Services.AddAuthorization();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPasswordHasher<Benutzer>, PasswordHasher<Benutzer>>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
