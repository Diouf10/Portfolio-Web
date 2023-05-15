using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP_WEB.Models;

namespace TP_WEB.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly SiteContext _context;

        public PortfoliosController(SiteContext context)
        {
            _context = context;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            return _context.Portfolios != null ?
                    View(await _context.Portfolios.Include(p => p.Image).ToListAsync()) :
                    Problem("Entity  set 'siteContext.Portfolios' is null.");
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomProjet,DescriptionProjet,TypeProjet,ImageID,TechnologieUtilise,NombreHeure,AdresseWeb,RoleProjet,Afficher")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                if(Request.Form.Files.Count > 0) 
                { 
                    var file = Request.Form.Files.SingleOrDefault();

                    Image img = new Image()
                    {
                        NomImage = file!.FileName,
                        ContentType = file!.ContentType
                    };

                    MemoryStream stream = new MemoryStream();
                    file.CopyTo(stream);

                    img.ImageData = stream.ToArray();
                    stream.Close();
                    stream.Dispose();

                    _context.Add(img);
                    await _context.SaveChangesAsync();

                    portfolio.ImageID = img.Id;
                }
                _context.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }


            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null) 
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomProjet,DescriptionProjet,TypeProjet,ImageID,TechnologieUtilise,NombreHeure,AdresseWeb,RoleProjet,Afficher")] Portfolio portfolio)
        {
            if (id != portfolio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.ID))
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
            return View(portfolio);
        }

        [Authorize(Roles = "Administrateur")]
        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Portfolios == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .Include(p => p.Image)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrateur")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Portfolios == null)
            {
                return Problem("Entity set 'SiteContext.Portfolios'  is null.");
            }
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
          return (_context.Portfolios?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
