

using System.ComponentModel.DataAnnotations;

using VisitorManagement.Models;

namespace VisitorManagement.ViewModels
{
    public class VisitorVM
    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public string? Business { get; set; }
        [Display(Name = "Visit Date In")]
        public DateTime? DateIn { get; set; }
        [Display(Name = "Visit Date Out")]
        public DateTime? DateOut { get; set; }

        [Display(Name = "Staff Person Visited")]
        public Guid StaffNameId { get; set; }
        [Display(Name = "Staff Person Visited")]
        public StaffNames? StaffName { get; set; }
    }
}
