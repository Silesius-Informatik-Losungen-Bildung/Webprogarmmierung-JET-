namespace PersonenVerwaltung.Viewmodels
{
    public class DetailsViewmodel
    {
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public int? Alter { get; set; }
        public string Standort { get; set; } = null!;
    }
}
