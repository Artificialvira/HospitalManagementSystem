namespace Hospital.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public Hospitals Hospital { get; set; }
    }
}