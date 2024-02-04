using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecommerce.Data;
using ecommerce.Models;

namespace ecommerce.Controllers
{
    public class ligne_CommandeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ligne_CommandeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ligne_Commande
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ligne_Commande.Include(l => l.Commande).Include(l => l.Produit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ligne_Commande/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ligne_Commande == null)
            {
                return NotFound();
            }

            var ligne_Commande = await _context.ligne_Commande
                .Include(l => l.Commande)
                .Include(l => l.Produit)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ligne_Commande == null)
            {
                return NotFound();
            }

            return View(ligne_Commande);
        }

        // GET: ligne_Commande/Create
        public IActionResult Create()
        {
            ViewData["CommandeId"] = new SelectList(_context.Set<Commande>(), "Id", "Id");
            ViewData["ProduitId"] = new SelectList(_context.Produit, "id", "id");
            return View();
        }

        // POST: ligne_Commande/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProduitId,CommandeId")] ligne_Commande ligne_Commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ligne_Commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommandeId"] = new SelectList(_context.Set<Commande>(), "Id", "Id", ligne_Commande.CommandeId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "id", "id", ligne_Commande.ProduitId);
            return View(ligne_Commande);
        }

        // GET: ligne_Commande/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ligne_Commande == null)
            {
                return NotFound();
            }

            var ligne_Commande = await _context.ligne_Commande.FindAsync(id);
            if (ligne_Commande == null)
            {
                return NotFound();
            }
            ViewData["CommandeId"] = new SelectList(_context.Set<Commande>(), "Id", "Id", ligne_Commande.CommandeId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "id", "id", ligne_Commande.ProduitId);
            return View(ligne_Commande);
        }

        // POST: ligne_Commande/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProduitId,CommandeId")] ligne_Commande ligne_Commande)
        {
            if (id != ligne_Commande.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ligne_Commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ligne_CommandeExists(ligne_Commande.ID))
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
            ViewData["CommandeId"] = new SelectList(_context.Set<Commande>(), "Id", "Id", ligne_Commande.CommandeId);
            ViewData["ProduitId"] = new SelectList(_context.Produit, "id", "id", ligne_Commande.ProduitId);
            return View(ligne_Commande);
        }

        // GET: ligne_Commande/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ligne_Commande == null)
            {
                return NotFound();
            }

            var ligne_Commande = await _context.ligne_Commande
                .Include(l => l.Commande)
                .Include(l => l.Produit)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ligne_Commande == null)
            {
                return NotFound();
            }

            return View(ligne_Commande);
        }

        // POST: ligne_Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ligne_Commande == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ligne_Commande'  is null.");
            }
            var ligne_Commande = await _context.ligne_Commande.FindAsync(id);
            if (ligne_Commande != null)
            {
                _context.ligne_Commande.Remove(ligne_Commande);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ligne_CommandeExists(int id)
        {
          return (_context.ligne_Commande?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
