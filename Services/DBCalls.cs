using VisitorManagement.Data;
using VisitorManagement.Models;

namespace VisitorManagement.Services
{
    public class DBCalls : IDBCalls
    {

        private readonly ApplicationDbContext _context;

        public DBCalls(ApplicationDbContext context)
        {
            _context = context;
        }

        //https://www.infoq.com/news/2021/04/Net6-Linq/ new toys in Linq


        /// <summary>
        /// Top 5 visitors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StaffNames> Top5StaffVisitors()
        {
            //get a list of all the popular staff
            List<StaffNames> PopularStaff = new List<StaffNames>();

            IEnumerable<StaffNames> AllStaff = _context.StaffNames
                .Take(5)
                .OrderByDescending(i => i.VisitorCount)
                .ThenBy(i => i.Name)
                .ToList();
            return AllStaff.ToList();
        }
        /// <summary>
        /// List of Visitors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Visitor> UniqueVisitorNames()
        {
            return _context.Visitor.Distinct().OrderBy(v => v.FirstName).ToList();
        }

        /// <summary>
        /// Get all the visitors who havn't left yet
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Visitor> VisitorsLoggedIn()
        {
            return _context.Visitor.OrderByDescending(v => v.DateIn).Where(v => v.DateOut == null).ToList();
        }

        public IEnumerable<Visitor> VisitorsInTheLast7days()
        {
            return _context.Visitor
                                 .Where(v => v.DateIn > DateTime.Today.AddDays(-7))
                                 .OrderBy(v => v.DateIn)
                                 .Select(s => new Visitor { FirstName = s.FirstName, LastName = s.LastName, StaffName = s.StaffName })
                              .ToList();
        }


    }




}

