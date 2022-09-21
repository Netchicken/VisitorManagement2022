using VisitorManagement.Data;
using VisitorManagement.Models;
using VisitorManagement.ViewModels;

namespace VisitorManagement.Services
{
    public class DBCalls : IDBCalls
    {


        //          from[identifier] in [data source]
        //          let[expression]
        //          where[boolean expression]
        //          order by[[expression] (ascending/descending)], [optionally repeat]
        //          select[expression]
        //          group[expression] by[expression] into[expression]







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


        /// <summary>
        /// Get all customers in teh last 7 days
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Visitor> VisitorsInTheLast7days()
        {
            return _context.Visitor
                                 .Where(v => v.DateIn > DateTime.Today.AddDays(-2))
                                 .OrderBy(v => v.DateIn)
                                 .Select(s => new Visitor { FirstName = s.FirstName, LastName = s.LastName, StaffName = s.StaffName, DateIn = s.DateIn })
                              .ToList();
        }



        //https://www.tutorialsteacher.com/linq



        public IEnumerable<Visitor> WhereQuery()
        {
            var query = from c in _context.Visitor
                        where c.FirstName == "John"
                        select c;
            return query;
        }


        public IEnumerable<Visitor> WhereQueryLambda()
        {
            return _context.Visitor.Where(c => c.FirstName.Contains( "la"));

        }
        //OrderBy and ThenBy sorts collections in ascending order by default.
        //ThenByDescending method sorts the collection in decending order on another field.

        public IEnumerable<StaffNames> OrderByLambda()
        {
            return _context.StaffNames.OrderBy(c => c.VisitorCount);
            // var queryThenBy = _context.StaffNames.OrderBy(c => c.VisitorCount).ThenBy(s => s.Name);

        }


        public IEnumerable<StaffNames> SelectMethodQuery()
        {
            //select a single field
            // var query = _context.StaffNames.Select(s => s.Name);


            //select a multiple field this is called a projection query
            return _context.StaffNames.Select(s => new StaffNames { Name = s.Name, Department = s.Department });

        }



        public IEnumerable<GroupBy> GroupByQuery()
        {

            return _context.Visitor.GroupBy(v => v.DateIn.Value.Day).Select(g => new GroupBy { Day = g.Key, Count = g.Count() });

        }

        public IEnumerable<GroupByStaff> GroupByStaffQuery()
        {

            return _context.Visitor.GroupBy(v => v.StaffName.Name).Select(g => new GroupByStaff { Staff = g.Key, Count = g.Count() });

        }


        
    }




}

