﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IDBCalls _dbCalls;


        public HomeController(ILogger<HomeController> logger, ITextFileOperations textFileOperations, ApplicationDbContext context, IDataSeeder dataSeeder, IDBCalls dbCalls)
        {
            _logger = logger;
            _textFileOperations = textFileOperations;
            _context = context;
            _dataSeeder = dataSeeder;
            _dbCalls = dbCalls;
        }

        public IActionResult Index()
        {
            //run the dataseeder
            //  _dataSeeder.SeedStaffAsync();
            //  _dataSeeder.SeedVisitorsAsync();

            ViewBag.Welcome = "Welcome to the VMS";


            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();
            ViewData["TopStaff"] = _dbCalls.Top5StaffVisitors();
            ViewData["LoggedInVIsitors"] = _dbCalls.VisitorsLoggedIn();
            ViewData["Last7DaysVisitors"] = _dbCalls.VisitorsInTheLast7days();

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

        //copied over from the VisitorsController
        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Business,DateIn,DateOut,StaffNameId")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                //get a new guid
                visitor.Id = Guid.NewGuid();

                //increase the counter 
                var staff = _context.StaffNames.Find(visitor.StaffNameId);
                staff.VisitorCount++;
                _context.Update(staff);

                //add the new visitor to the context
                _context.Add(visitor);
                //save the data to the database
                await _context.SaveChangesAsync();

                string message = "Thank you for visiting " + staff.Name + " today";
                string welcome = "Welcome " + visitor.FirstName + " " + visitor.LastName;
                Alert(message, welcome);//add this method



                //reload the page in the controller that is the index page.
                return RedirectToAction(nameof(Index));
            }
            //reloads the select list
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Id", visitor.StaffNameId);
            return View(visitor);
        }


        /// <summary>
        /// Pass through the ID of the visitor clicked and then insert the logout date into the field
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //with a link
        //https://localhost:7088/Home/Logout/75988a8d-f37c-42ca-9a1f-3dfdbf26e6dc
        //with a button

        //formaction="/Home/Logout?id=7a0e09b4-e944-4846-bcc3-b8afc94076c7"


        [Route("/Home/Logout", Name = "LogoutRoute")]
        public async Task<IActionResult> Logout(Guid? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            visitor.DateOut = DateTime.Now;


            //update the visitor to the context
            _context.Update(visitor);
            //save the data to the database
            await _context.SaveChangesAsync();

            //go to the Index method on the Home Controller
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// SweetAlert popups
        /// </summary>
        /// <param name="id"></param>
        public void Alert(string name, string welcome)
        {
            var msg = "<script language='javascript'>Swal.fire({" +
                "title: Visitor Management System'," +
                "text: '" + welcome + " " + name + "', " +
                "icon: 'success', " +
                "timer:'2000'})</script>";

            var msg2 = welcome +" "+ name;

            TempData["notification"] = msg;

            ViewData["Message"] = msg2;
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