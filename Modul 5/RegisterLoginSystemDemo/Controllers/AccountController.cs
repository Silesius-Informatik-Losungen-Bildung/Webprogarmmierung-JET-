using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using RegisterLoginSystemDemo.Models;
using RegisterLoginSystemDemo.ViewModels;
using RegisterLoginSystemDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace RegisterLoginSystemDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<Benutzer> _hasher;

        public AccountController(AppDbContext context, IPasswordHasher<Benutzer> hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var benutzer = await _context.Benutzer
                .FirstOrDefaultAsync(b =>b.Benutzername.ToLower() == model.Benutzername.Trim().ToLower()
                || b.Email.ToLower() == model.Email.Trim().ToLower());
            if (benutzer != null)
            {
                ModelState.AddModelError("", "Benutzername oder E-Mail bereits in Verwendung.");
                return View(model);
            }

            benutzer = new Benutzer
            {
                Benutzername = model.Benutzername,
                Email = model.Email,
                Rolle = "User"
            };
            benutzer.PasswortHash = _hasher.HashPassword(benutzer, model.Passwort);


            _context.Benutzer.Add(benutzer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var benutzer = await _context.Benutzer.FirstOrDefaultAsync(b => b.Benutzername == model.Benutzername);

            if (benutzer == null)
            {
                ModelState.AddModelError("", "Benutzer nicht gefunden");
                return View(model);
            }

            var result = _hasher.VerifyHashedPassword(benutzer, benutzer.PasswortHash, model.Passwort);
            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("", "Falsches Passwort");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, benutzer.Benutzername),
                new Claim(ClaimTypes.Role, benutzer.Rolle)
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
