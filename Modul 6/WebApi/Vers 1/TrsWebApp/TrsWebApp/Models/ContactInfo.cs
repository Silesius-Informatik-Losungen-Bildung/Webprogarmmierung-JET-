namespace TrsWebApp.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
