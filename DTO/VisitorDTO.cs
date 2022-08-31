namespace VisitorManagement.Models
{
    public class VisitorDTO
    {
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Business { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public StaffNames StaffName { get; set; }


    }
}
