using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VisitorManagement.ViewModels
{
    public class StaffNamesVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Staff Name")]
        public string? Name { get; set; }
        public string? Department { get; set; }

        [Display(Name = "Count of Visitors")]
        public int? VisitorCount { get; set; }
        //public List<Visitor>? Visitors { get; set; }

    }
}
