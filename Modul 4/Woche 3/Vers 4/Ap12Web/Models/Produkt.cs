using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ap12Web.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        
        [MaxLength(30)]
        [Required(ErrorMessage ="Bezeichnung muss ausgefüllt werden.")]
        [Display(Name = "Produktname")]
        public string Bezeichnung { get; set; } = null!;
        
        public double Preis { get; set; }

        public DateTime EingefügtAm { get; set; } = DateTime.Now;
        public int HerstellerId { get; set; }

        [NotMapped]
        public List<Hersteller> HerstellerList { get; set; } = new List<Hersteller>();
        
        public virtual Hersteller? Hersteller { get; set; }
    }
}
