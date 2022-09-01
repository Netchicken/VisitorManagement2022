using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VisitorManagement.Data;
using VisitorManagement.Models;

namespace VisitorManagement.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visitors
        public async Task<IActionResult> Index()
        {
            return _context.Visitor != null ?
                        View(await _context.Visitor.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Visitor'  is null.");
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Visitor == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor
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
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Business,DateIn,DateOut")] Visitor visitor)
        {
            DateTime thisDay = DateTime.Today;

            //  if (ModelState.IsValid)
            {
                visitor.Id = Guid.NewGuid();
                //if the visitor dateis enpty add in todays date
                // visitor.DateIn =  visitor.DateIn == null  ? thisDay : thisDay;
                // visitor.DateOut = visitor.DateOut == null ? thisDay : thisDay;
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Business,DateIn,DateOut")] Visitor visitor)
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
