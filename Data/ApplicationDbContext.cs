using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VisitorManagement.Models;

namespace VisitorManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VisitorManagement.Models.StaffNames>? StaffNames { get; set; }
        public DbSet<VisitorManagement.Models.Visitor>? Visitor { get; set; }
    }
}