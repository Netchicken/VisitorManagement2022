using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Diagnostics;

using VisitorManagement.Data;
using VisitorManagement.Models;
using VisitorManagement.Services;

namespace VisitorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITextFileOperations _textFileOperations;
        private readonly ApplicationDbContext _context;
        private readonly IDataSeeder _dataSeeder;


        public HomeController(ILogger<HomeController> logger, ITextFileOperations textFileOperations, ApplicationDbContext context, IDataSeeder dataSeeder)
        {
            _logger = logger;
            _textFileOperations = textFileOperations;
            _context = context;
            _dataSeeder = dataSeeder;
        }

        public IActionResult Index()
        {
            //run the dataseeder
            _dataSeeder.SeedAsync();


            ViewBag.Welcome = "Welcome to the VMS";


            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();



            var staffList = new SelectList(_context.StaffNames, "Id", "Name");


            ViewData["StaffNameId"] = staffList;

            //create an instance of the visitor
            Visitor visitor = new Visitor();
            //pass in the currentdate and time to the Datein property
            visitor.DateIn = DateTime.Now;

            //send that visitor to the Create View
            return View(visitor);

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}