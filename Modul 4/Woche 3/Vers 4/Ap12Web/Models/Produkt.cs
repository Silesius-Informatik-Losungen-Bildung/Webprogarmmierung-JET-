using System.ComponentModel.DataAnnotations;

namespace Ap12Web.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        [MaxLength(30)]
        public string Bezeichnung { get; set; } = null!;
        public double Preis { get; set; }

        public DateTime EingefügtAm { get; set; } = DateTime.Now;
        public int HerstellerId { get; set; }
        public virtual Hersteller Hersteller { get; set; } = new Hersteller();
    }
}
