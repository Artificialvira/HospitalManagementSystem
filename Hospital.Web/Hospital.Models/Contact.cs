namespace Hospital.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Hospitals Hospital { get; set; }
        public int HospitalId { get; set; }
    }
}