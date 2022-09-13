using VisitorManagement.Models;

namespace VisitorManagement.Services
{
    public interface IDBCalls
    {

        IEnumerable<StaffNames> Top5StaffVisitors();
        IEnumerable<Visitor> UniqueVisitorNames();
        IEnumerable<Visitor> VisitorsLoggedIn();
        IEnumerable<Visitor> VisitorsInTheLast7days();
    }
}