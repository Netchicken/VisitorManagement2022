using VisitorManagement.Models;
using VisitorManagement.ViewModels;

namespace VisitorManagement.Services
{
    public interface IDBCalls
    {

        IEnumerable<StaffNames> Top5StaffVisitors();
        IEnumerable<Visitor> UniqueVisitorNames();
        IEnumerable<Visitor> VisitorsLoggedIn();
        IEnumerable<Visitor> VisitorsInTheLast7days();
        IEnumerable<Visitor> WhereQueryLambda();
        IEnumerable<StaffNames> OrderByLambda();
        IEnumerable<StaffNames> SelectMethodQuery();
        IEnumerable<GroupBy> GroupByQuery();
        IEnumerable<GroupByStaff> GroupByStaffQuery();
    }
}