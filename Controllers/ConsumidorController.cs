using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet_order_app.Models;

namespace dotnet_order_app.Controllers
{
    public class ConsumidorController : Controller
    {
        private readonly MyDbContext _context;

        public ConsumidorController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Consumidor
        public async Task<IActionResult> Index()
        {
              return _context.Consumidores != null ? 
                          View(await _context.Consumidores.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Consumidores'  is null.");
        }

        // GET: Consumidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consumidores == null)
            {
                return NotFound();
            }

            var consumidor = await _context.Consumidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumidor == null)
            {
                return NotFound();
            }

            return View(consumidor);
        }

        // GET: Consumidor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumidor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Consumidor consumidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumidor);
        }

        // GET: Consumidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consumidores == null)
            {
                return NotFound();
            }

            var consumidor = await _context.Consumidores.FindAsync(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return View(consumidor);
        }

        // POST: Consumidor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Consumidor consumidor)
        {
            if (id != consumidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumidorExists(consumidor.Id))
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
            return View(consumidor);
        }

        // GET: Consumidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consumidores == null)
            {
                return NotFound();
            }

            var consumidor = await _context.Consumidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumidor == null)
            {
                return NotFound();
            }

            return View(consumidor);
        }

        // POST: Consumidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consumidores == null)
            {
                return Problem("Entity set 'MyDbContext.Consumidores'  is null.");
            }
            var consumidor = await _context.Consumidores.FindAsync(id);
            if (consumidor != null)
            {
                _context.Consumidores.Remove(consumidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumidorExists(int id)
        {
          return (_context.Consumidores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
