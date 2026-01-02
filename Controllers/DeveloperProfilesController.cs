using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class DeveloperProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeveloperProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeveloperProfiles
        public async Task<IActionResult> Index()
        {
              return _context.DeveloperProfiles != null ? 
                          View(await _context.DeveloperProfiles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DeveloperProfiles'  is null.");
        }

        // GET: DeveloperProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeveloperProfiles == null)
            {
                return NotFound();
            }

            var developerProfile = await _context.DeveloperProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developerProfile == null)
            {
                return NotFound();
            }

            return View(developerProfile);
        }

        // GET: DeveloperProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeveloperProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Skills,YearsOfExperience,Location,OpenToWork")] DeveloperProfile developerProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developerProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developerProfile);
        }

        // GET: DeveloperProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeveloperProfiles == null)
            {
                return NotFound();
            }

            var developerProfile = await _context.DeveloperProfiles.FindAsync(id);
            if (developerProfile == null)
            {
                return NotFound();
            }
            return View(developerProfile);
        }

        // POST: DeveloperProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Skills,YearsOfExperience,Location,OpenToWork")] DeveloperProfile developerProfile)
        {
            if (id != developerProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperProfileExists(developerProfile.Id))
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
            return View(developerProfile);
        }

        // GET: DeveloperProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeveloperProfiles == null)
            {
                return NotFound();
            }

            var developerProfile = await _context.DeveloperProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developerProfile == null)
            {
                return NotFound();
            }

            return View(developerProfile);
        }

        // POST: DeveloperProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeveloperProfiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeveloperProfiles'  is null.");
            }
            var developerProfile = await _context.DeveloperProfiles.FindAsync(id);
            if (developerProfile != null)
            {
                _context.DeveloperProfiles.Remove(developerProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeveloperProfileExists(int id)
        {
          return (_context.DeveloperProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
