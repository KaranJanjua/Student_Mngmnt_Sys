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
    public class EtwoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtwoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etwoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etwo.ToListAsync());
        }

        // GET: Etwoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etwo = await _context.Etwo
                .FirstOrDefaultAsync(m => m.EnrolName_Id == id);
            if (etwo == null)
            {
                return NotFound();
            }

            return View(etwo);
        }

        // GET: Etwoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etwoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrolName_Id,First_Name,Last_Name,Course_Name,class_Location")] Etwo etwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etwo);
        }

        // GET: Etwoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etwo = await _context.Etwo.FindAsync(id);
            if (etwo == null)
            {
                return NotFound();
            }
            return View(etwo);
        }

        // POST: Etwoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrolName_Id,First_Name,Last_Name,Course_Name,Course_Location")] Etwo etwo)
        {
            if (id != etwo.EnrolName_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtwoExists(etwo.EnrolName_Id))
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
            return View(etwo);
        }

        // GET: Etwoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etwo = await _context.Etwo
                .FirstOrDefaultAsync(m => m.EnrolName_Id == id);
            if (etwo == null)
            {
                return NotFound();
            }

            return View(etwo);
        }

        // POST: Etwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etwo = await _context.Etwo.FindAsync(id);
            _context.Etwo.Remove(etwo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtwoExists(int id)
        {
            return _context.Etwo.Any(e => e.EnrolName_Id == id);
        }
    }
}
