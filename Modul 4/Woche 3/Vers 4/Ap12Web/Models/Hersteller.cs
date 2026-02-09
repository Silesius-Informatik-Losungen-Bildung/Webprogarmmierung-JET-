using System.ComponentModel.DataAnnotations;

namespace Ap12Web.Models
{
    public class Hersteller
    {
        public int HerstellerId { get; set; }
        [MaxLength(60)]
        public string Name { get; set; } = null!;
		public DateTime EingefügtAm { get; set; } = DateTime.Now;
        public virtual ICollection<Produkt> Produkte { get; set; } = new List<Produkt>();
	}
}
