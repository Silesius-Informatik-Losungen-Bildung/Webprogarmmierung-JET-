using System.ComponentModel.DataAnnotations;

namespace PersonenVerwaltung.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [MaxLength(5)]
        public string Vorname { get; set; } = null!;
        [MaxLength(5)]
        public string Nachname { get; set; } = null!;
        public int? Alter {  get; set; }

        public int StandortId { get; set; }

        public Standort Standort { get; set; } = null!;
    }
}
