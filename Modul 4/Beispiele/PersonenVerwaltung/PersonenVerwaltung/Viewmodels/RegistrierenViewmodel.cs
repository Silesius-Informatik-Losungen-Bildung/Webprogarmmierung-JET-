using System.ComponentModel.DataAnnotations;

namespace PersonenVerwaltung.Viewmodels
{
    public class RegistrierenViewmodel
    {
        [MaxLength(20)]
        public string Vorname { get; set; } = null!;
        [MaxLength(20)]
        public string Nachname { get; set; } = null!;
        public int? Alter { get; set; }
        public int StandortId { get; set; }
    }
}
