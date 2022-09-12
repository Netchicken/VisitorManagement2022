using VisitorManagement.Models;

namespace VisitorManagement.Services
{
    public interface IDBCalls
    {
        void IncrementStaffCount(int id);
        IEnumerable<StaffNames> Top5StaffVisitors();
        IEnumerable<Visitor> UniqueVisitorNames();
        IEnumerable<Visitor> VisitorsLoggedIn();
    }
}