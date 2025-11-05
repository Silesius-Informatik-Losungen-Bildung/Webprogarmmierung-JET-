using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PersonenVerwaltung.Viewmodels
{
    public class RegistrierenViewmodel
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Vorname fehlt!")]
        public string Vorname { get; set; } = null!;
        
        [MaxLength(20)]
        [Required(ErrorMessage = "Nachname fehlt!")]
        public string Nachname { get; set; } = null!;
        
        public int? Alter { get; set; }
        
        [Required(ErrorMessage = "StandortId fehlt!")]
        public int StandortId { get; set; }

        public IEnumerable<SelectListItem>? StandortListe { get; set; } 
    }
}
