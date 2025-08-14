namespace RegisterLoginSystemDemo.Models;

public class Benutzer
{
    public int BenutzerId { get; set; }
    public string Benutzername { get; set; } = null!;
    public string PasswortHash { get; set; } = null!;
    public string Rolle { get; set; } = null!;
    public string Email { get; set; } = null!;
}
