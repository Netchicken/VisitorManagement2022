using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VisitorManagement.Data;
using VisitorManagement.Models;
using VisitorManagement.Services;

namespace VisitorManagement.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDBCalls _dbCalls;

        public VisitorsController(ApplicationDbContext context, IDBCalls dbCalls)
        {
            _context = context;
            _dbCalls = dbCalls;
        }

        // GET: Visitors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Visitor.Include(v => v.StaffName);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor
                .Include(v => v.StaffName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            var staffList = new SelectList(_context.StaffNames, "Id", "Name");


            ViewData["StaffNameId"] = staffList;

            //create an instance of the visitor
            Visitor visitor = new Visitor();
            //pass in the currentdate and time to the Datein property
            visitor.DateIn = DateTime.Now;

            //send that visitor to the Create View
            return View(visitor);
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Business,DateIn,DateOut,StaffNameId")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                //increase the counter 
                //increase the counter 
                var staff = _context.StaffNames.Find(visitor.StaffNameId);
                staff.VisitorCount++;
                _context.Update(staff);




                visitor.Id = Guid.NewGuid();
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Id", visitor.StaffNameId);
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Name", visitor.StaffNameId);
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Business,DateIn,DateOut,StaffNameId")] Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorExists(visitor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffNameId"] = new SelectList(_context.StaffNames, "Id", "Id", visitor.StaffNameId);
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor
                .Include(v => v.StaffName)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Visitor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Visitor'  is null.");
            }
            var visitor = await _context.Visitor.FindAsync(id);
            if (visitor != null)
            {
                _context.Visitor.Remove(visitor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(Guid id)
        {
            return (_context.Visitor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
