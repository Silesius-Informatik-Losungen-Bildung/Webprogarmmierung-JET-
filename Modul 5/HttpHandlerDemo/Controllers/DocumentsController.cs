using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

public class DocumentsController : Controller
{

    public async Task<IActionResult> Image(int id)
    {
        // Hier könnte man das Bild mit der id direkt aus DB abrufen
        var pfad = Path.Combine("wwwroot", "media", "Kinder.jpg");
        var doc = await System.IO.File.ReadAllBytesAsync(pfad);
        
        if (doc == null)
            return NotFound();

        var mimeType = GetMimeType(pfad);
        return File(doc, mimeType);
    }

    public async Task<IActionResult> Doc(int id)
    {
        // Hier könnte man das Document mit der id direkt aus DB abrufen
        var pfad = Path.Combine("wwwroot", "media", "Erste Schritte mit OneDrive.pdf");
        var doc = await System.IO.File.ReadAllBytesAsync(pfad);
        if (doc == null)
            return NotFound();

        var mimeType = GetMimeType(pfad);
        return File(doc, mimeType, "Dokument.pdf");
    }

    public async Task<IActionResult> Mp4(int id)
    {
        // Hier könnte man das Video mit der id direkt aus DB abrufen
        var pfad = Path.Combine("wwwroot", "media", "Erde.mp4");
        var doc = await System.IO.File.ReadAllBytesAsync(pfad);

        if (doc == null)
            return NotFound();

        var mimeType = GetMimeType(pfad);
        return File(doc, mimeType);
    }

    private static string GetMimeType(string filePath)
    {
        var provider = new FileExtensionContentTypeProvider();

        if (provider.TryGetContentType(filePath, out var contentType))
        {
            return contentType;
        }
        return "application/octet-stream";
    }
}