using BenutzerVerwaltung.Models;

namespace BenutzerVerwaltung.Data
{
    public static class BenutzerData
    {
        static BenutzerData()
        {
            BenutzerListe = new List<Benutzer>();
        }

        public static List<Benutzer> BenutzerListe { get; set; }
    }
}
