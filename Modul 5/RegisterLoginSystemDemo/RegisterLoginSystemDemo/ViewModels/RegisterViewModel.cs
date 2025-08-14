using System.ComponentModel.DataAnnotations;

namespace RegisterLoginSystemDemo.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(30)]
        public string Benutzername { get; set; } = null!;
        
        [MaxLength(20)]
        public string Passwort { get; set; } = null!;
        
        [EmailAddress()]
        [MaxLength(30)]
        public string Email { get; set; } = null!;
    }
}