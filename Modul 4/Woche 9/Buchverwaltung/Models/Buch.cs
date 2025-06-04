using System.ComponentModel.DataAnnotations;

namespace Buchverwaltung.Models
{
    public class Buch
    {
        public int? Id { get; set; }
        public string Titel { get; set; } = null!;

        [MaxLength(6)]
        public string ISBN { get; set; } = null!;
        public string Autor { get; set; } = null!;

        [Range(1500, 2025, ErrorMessage = "Bitte geben Sie ein Jahr zwischen 1500 und 2100 ein.")]
        public int Erscheinungsjahr { get; set; }
        public bool IsSelected { get; set; }
    }
}
