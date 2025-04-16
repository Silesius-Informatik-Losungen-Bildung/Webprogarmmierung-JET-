namespace Buchverwaltung.Models
{
    public class Buch
    {
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int Erscheinungsjahr { get; set; }
    }
}
