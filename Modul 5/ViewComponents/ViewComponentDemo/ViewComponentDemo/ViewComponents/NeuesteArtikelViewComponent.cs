using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentDemo.Data;

namespace ViewComponentDemo.ViewComponents
{
    public class NeuesteArtikelViewComponent : ViewComponent
    {
        private readonly DemoContext _context;
        public NeuesteArtikelViewComponent(DemoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var artikel = await _context.Artikel
                .OrderByDescending(a => a.ErstelltAm)
                .Take(3)
                .ToListAsync();
            return View(artikel);
        }
    }
}
