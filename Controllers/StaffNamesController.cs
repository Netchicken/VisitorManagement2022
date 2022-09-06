using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VisitorManagement.Data;
using VisitorManagement.Models;
using VisitorManagement.ViewModels;

namespace VisitorManagement.Controllers
{
    public class StaffNamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StaffNamesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: StaffNames
        public async Task<IActionResult> Index()
        {
            //beware of await causing errors that are wierd, you must have it in the code.
            var staffNames = _context.StaffNames.ToListAsync(); //get the data from the DB
            //map it to the StaffnamesVM from teh StaffNames class
            var StaffNamesVM = _mapper.Map<IEnumerable<StaffNamesVM>>(await staffNames);
            //carry on with default code
            return _context.StaffNames != null ?
                        View(StaffNamesVM) :
                        Problem("Entity set 'ApplicationDbContext.StaffNames'  is null.");
        }

        // GET: StaffNames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {//this is all default code
            if (id == null || _context.StaffNames == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }
            //make changes here at the end
            var StaffNamesVM = _mapper.Map<StaffNamesVM>(staffNames);
            return View(StaffNamesVM);
        }

        // GET: StaffNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (ModelState.IsValid)
            {
                staffNames.Id = Guid.NewGuid();
                _context.Add(staffNames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffNames);
        }

        // GET: StaffNames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.StaffNames == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames.FindAsync(id);
            if (staffNames == null)
            {
                return NotFound();
            }
            return View(staffNames);
        }

        // POST: StaffNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Department,VisitorCount")] StaffNames staffNames)
        {
            if (id != staffNames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffNames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffNamesExists(staffNames.Id))
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
            return View(staffNames);
        }

        // GET: StaffNames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.StaffNames == null)
            {
                return NotFound();
            }

            var staffNames = await _context.StaffNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staffNames == null)
            {
                return NotFound();
            }

            return View(staffNames);
        }

        // POST: StaffNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.StaffNames == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StaffNames'  is null.");
            }
            var staffNames = await _context.StaffNames.FindAsync(id);
            if (staffNames != null)
            {
                _context.StaffNames.Remove(staffNames);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffNamesExists(Guid id)
        {
            return (_context.StaffNames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
