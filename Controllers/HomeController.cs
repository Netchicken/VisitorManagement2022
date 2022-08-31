using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using VisitorManagement.Models;
using VisitorManagement.Services;

namespace VisitorManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITextFileOperations _textFileOperations;



        public HomeController(ILogger<HomeController> logger, ITextFileOperations textFileOperations)
        {
            _logger = logger;
            _textFileOperations = textFileOperations;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to the VMS";

            ViewBag.VisitorNew = new Visitor()
            {
                FirstName = "Howard",
                LastName = "The Barbarian"
            };

            ViewData["AnotherWelcome"] = "Please enter your Name";


            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();

            return View();
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