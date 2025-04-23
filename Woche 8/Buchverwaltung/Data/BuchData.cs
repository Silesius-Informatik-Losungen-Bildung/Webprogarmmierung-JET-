using Buchverwaltung.Models;

namespace Buchverwaltung.Data
{
    public static class BuchData
    {
        public static List<Buch> Buecher {  get; set; }
        static BuchData()
        {
            Buecher = new List<Buch>();
        }
    }
}
