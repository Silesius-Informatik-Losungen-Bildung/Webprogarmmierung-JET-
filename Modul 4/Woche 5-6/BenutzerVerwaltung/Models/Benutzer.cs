namespace BenutzerVerwaltung.Models
{
    public class Benutzer
    {
        public required string Vorname { get; set; }
        public required string Nachname { get; set; }
        public int Alter { get; set; }
    }

}
