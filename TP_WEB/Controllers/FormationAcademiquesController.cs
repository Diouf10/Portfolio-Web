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
    public class FormationAcademiquesController : Controller
    {
        private readonly SiteContext _context;

        public FormationAcademiquesController(SiteContext context)
        {
            _context = context;
        }

        // GET: FormationAcademiques
        public async Task<IActionResult> Index()
        {
              return _context.FormationAcademiques != null ? 
                          View(await _context.FormationAcademiques.ToListAsync()) :
                          Problem("Entity set 'SiteContext.FormationAcademiques'  is null.");
        }

        // GET: FormationAcademiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormationAcademiques == null)
            {
                return NotFound();
            }

            var formationAcademique = await _context.FormationAcademiques
                .FirstOrDefaultAsync(m => m.ID == id);
            if (formationAcademique == null)
            {
                return NotFound();
            }

            return View(formationAcademique);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: FormationAcademiques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormationAcademiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomEcole,ProgrammeEtude,AnneeDebutFormation,AnneeFinFormation,LienProgrammeEtude,EstDiplomeObtenu")] FormationAcademique formationAcademique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formationAcademique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formationAcademique);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: FormationAcademiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormationAcademiques == null)
            {
                return NotFound();
            }

            var formationAcademique = await _context.FormationAcademiques.FindAsync(id);
            if (formationAcademique == null)
            {
                return NotFound();
            }
            return View(formationAcademique);
        }

        // POST: FormationAcademiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomEcole,ProgrammeEtude,AnneeDebutFormation,AnneeFinFormation,LienProgrammeEtude,EstDiplomeObtenu")] FormationAcademique formationAcademique)
        {
            if (id != formationAcademique.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formationAcademique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormationAcademiqueExists(formationAcademique.ID))
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
            return View(formationAcademique);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: FormationAcademiques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormationAcademiques == null)
            {
                return NotFound();
            }

            var formationAcademique = await _context.FormationAcademiques
                .FirstOrDefaultAsync(m => m.ID == id);
            if (formationAcademique == null)
            {
                return NotFound();
            }

            return View(formationAcademique);
        }

        [Authorize(Roles = "Administrateur")]
        // POST: FormationAcademiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormationAcademiques == null)
            {
                return Problem("Entity set 'SiteContext.FormationAcademiques'  is null.");
            }
            var formationAcademique = await _context.FormationAcademiques.FindAsync(id);
            if (formationAcademique != null)
            {
                _context.FormationAcademiques.Remove(formationAcademique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormationAcademiqueExists(int id)
        {
          return (_context.FormationAcademiques?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
