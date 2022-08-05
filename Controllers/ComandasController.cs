using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Models;

namespace ProvaSuficienciaWebII.Controllers
{
    public class ComandasController : Controller
    {
        private readonly Context _context;

        public ComandasController(Context context)
        {
            _context = context;
        }

        // GET: Comandas
        public async Task<IActionResult> Index()
        {
              return _context.Comandas != null ? 
                          View(await _context.Comandas.ToListAsync()) :
                          Problem("Entity set 'Context.Comandas'  is null.");
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comandas == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comandas == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Comanda comanda)
        {
            if (id != comanda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.Id))
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
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comandas == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comandas == null)
            {
                return Problem("Entity set 'Context.Comandas'  is null.");
            }
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda != null)
            {
                _context.Comandas.Remove(comanda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
          return (_context.Comandas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
