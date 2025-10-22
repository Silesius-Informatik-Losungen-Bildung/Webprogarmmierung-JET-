namespace PersonenVerwaltung.Models
{
    public class Standort
    {
        public int StandortId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Person> Personen { get; set; } = null!;
    }
}
