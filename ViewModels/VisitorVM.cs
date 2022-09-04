

namespace VisitorManagement.ViewModels
{
    public class VisitorVM
    {
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Business { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public StaffNamesVM StaffName { get; set; }


    }
}
