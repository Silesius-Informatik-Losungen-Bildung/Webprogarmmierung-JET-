using System.ComponentModel.DataAnnotations;

namespace RegisterLoginSystemDemo.ViewModels
{
    public class LoginViewModel
    {
        [MaxLength(30)]
        public string Benutzername { get; set; } = null!;
        
        [MaxLength(20)]
        public string Passwort { get; set; } = null!;
    }
}