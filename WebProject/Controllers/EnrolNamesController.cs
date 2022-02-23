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
    public class EnrolNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrolNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnrolNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnrolName.ToListAsync());
        }

        // GET: EnrolNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolName = await _context.EnrolName
                .FirstOrDefaultAsync(m => m.EnrolName_Id == id);
            if (enrolName == null)
            {
                return NotFound();
            }

            return View(enrolName);
        }

        // GET: EnrolNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnrolNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrolName_Id,First_Name,Course_Name")] EnrolName enrolName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrolName);
        }

        // GET: EnrolNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolName = await _context.EnrolName.FindAsync(id);
            if (enrolName == null)
            {
                return NotFound();
            }
            return View(enrolName);
        }

        // POST: EnrolNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrolName_Id,First_Name,Course_Name")] EnrolName enrolName)
        {
            if (id != enrolName.EnrolName_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolNameExists(enrolName.EnrolName_Id))
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
            return View(enrolName);
        }

        // GET: EnrolNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolName = await _context.EnrolName
                .FirstOrDefaultAsync(m => m.EnrolName_Id == id);
            if (enrolName == null)
            {
                return NotFound();
            }

            return View(enrolName);
        }

        // POST: EnrolNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolName = await _context.EnrolName.FindAsync(id);
            _context.EnrolName.Remove(enrolName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolNameExists(int id)
        {
            return _context.EnrolName.Any(e => e.EnrolName_Id == id);
        }
    }
}
