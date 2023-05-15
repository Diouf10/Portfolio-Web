using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_WEB.Models;

namespace TP_WEB.Controllers
{
    public class ExperienceProfessionelsController : Controller
    {
        private readonly SiteContext _context;

        public ExperienceProfessionelsController(SiteContext context)
        {
            _context = context;
        }

        // GET: ExperienceProfessionels
        public async Task<IActionResult> Index()
        {
              return _context.ExperienceProfessionnels != null ? 
                          View(await _context.ExperienceProfessionnels.ToListAsync()) :
                          Problem("Entity set 'SiteContext.ExperienceProfessionnels'  is null.");
        }

        // GET: ExperienceProfessionels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExperienceProfessionnels == null)
            {
                return NotFound();
            }

            var experienceProfessionel = await _context.ExperienceProfessionnels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experienceProfessionel == null)
            {
                return NotFound();
            }

            return View(experienceProfessionel);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: ExperienceProfessionels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienceProfessionels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomEntreprise,PosteOccupe,DescriptionTaches,AnneeEmbauche,AnneeFinEmploi,SiteEntreprise")] ExperienceProfessionel experienceProfessionel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceProfessionel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienceProfessionel);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: ExperienceProfessionels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExperienceProfessionnels == null)
            {
                return NotFound();
            }

            var experienceProfessionel = await _context.ExperienceProfessionnels.FindAsync(id);
            if (experienceProfessionel == null)
            {
                return NotFound();
            }
            return View(experienceProfessionel);
        }

        // POST: ExperienceProfessionels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomEntreprise,PosteOccupe,DescriptionTaches,AnneeEmbauche,AnneeFinEmploi,SiteEntreprise")] ExperienceProfessionel experienceProfessionel)
        {
            if (id != experienceProfessionel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceProfessionel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceProfessionelExists(experienceProfessionel.ID))
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
            return View(experienceProfessionel);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: ExperienceProfessionels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExperienceProfessionnels == null)
            {
                return NotFound();
            }

            var experienceProfessionel = await _context.ExperienceProfessionnels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experienceProfessionel == null)
            {
                return NotFound();
            }

            return View(experienceProfessionel);
        }

        // POST: ExperienceProfessionels/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExperienceProfessionnels == null)
            {
                return Problem("Entity set 'SiteContext.ExperienceProfessionnels'  is null.");
            }
            var experienceProfessionel = await _context.ExperienceProfessionnels.FindAsync(id);
            if (experienceProfessionel != null)
            {
                _context.ExperienceProfessionnels.Remove(experienceProfessionel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceProfessionelExists(int id)
        {
          return (_context.ExperienceProfessionnels?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
