namespace VisitorManagement.Services
{
    public interface IDataSeeder
    {
        Task SeedStaffAsync();
        Task SeedVisitorsAsync();
    }
}