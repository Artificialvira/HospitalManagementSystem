namespace Hospital.Utilities
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public ICollection<ApplicationUser> Employees { get; set; }
    }
}