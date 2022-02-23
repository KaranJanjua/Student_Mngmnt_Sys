using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class EnrolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrols
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrol.Include(e => e.Courses).Include(e => e.Students);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrol = await _context.Enrol
                .Include(e => e.Courses)
                .Include(e => e.Students)
                .FirstOrDefaultAsync(m => m.Enrol_Id == id);
            if (enrol == null)
            {
                return NotFound();
            }

            return View(enrol);
        }

        // GET: Enrols/Create
        public IActionResult Create()
        {
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Id");
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Student_Id");
            return View();
        }

        // POST: Enrols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enrol_Id,Student_Id,Course_Id")] Enrol enrol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Id", enrol.Course_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Student_Id", enrol.Student_Id);
            return View(enrol);
        }

        // GET: Enrols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrol = await _context.Enrol.FindAsync(id);
            if (enrol == null)
            {
                return NotFound();
            }
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Id", enrol.Course_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Student_Id", enrol.Student_Id);
            return View(enrol);
        }

        // POST: Enrols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Enrol_Id,Student_Id,Course_Id")] Enrol enrol)
        {
            if (id != enrol.Enrol_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolExists(enrol.Enrol_Id))
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
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Id", enrol.Course_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Student_Id", enrol.Student_Id);
            return View(enrol);
        }

        // GET: Enrols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrol = await _context.Enrol
                .Include(e => e.Courses)
                .Include(e => e.Students)
                .FirstOrDefaultAsync(m => m.Enrol_Id == id);
            if (enrol == null)
            {
                return NotFound();
            }

            return View(enrol);
        }

        // POST: Enrols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrol = await _context.Enrol.FindAsync(id);
            _context.Enrol.Remove(enrol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolExists(int id)
        {
            return _context.Enrol.Any(e => e.Enrol_Id == id);
        }
    }
}
