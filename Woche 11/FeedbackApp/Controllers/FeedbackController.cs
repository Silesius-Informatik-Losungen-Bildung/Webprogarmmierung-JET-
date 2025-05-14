using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class FeedbackController : Controller
{
    private readonly FeedbackDbContext _context;

    public FeedbackController(FeedbackDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Submit(Feedback feedback)
    {
        if (!ModelState.IsValid)
            return View("Index", feedback);

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return RedirectToAction("ThankYou");
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}