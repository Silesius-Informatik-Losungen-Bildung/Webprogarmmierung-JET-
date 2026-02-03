using System.ComponentModel.DataAnnotations;

namespace Ap12Web.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }

        [MaxLength(30)]
        public string Bezeichnung { get; set; } = null!;
        public decimal Preis { get; set; }
        [MaxLength(30)]
        public string Hersteller { get; set; } = null!;
    }
}
