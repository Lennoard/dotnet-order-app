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
    public class BoletoController : Controller
    {
        private readonly MyDbContext _context;

        public BoletoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Boleto
        public async Task<IActionResult> Index()
        {
              return _context.Boletos != null ? 
                          View(await _context.Boletos.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Boletos'  is null.");
        }

        // GET: Boleto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boletos == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // GET: Boleto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boleto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Id,Valor")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boleto);
        }

        // GET: Boleto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boletos == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }
            return View(boleto);
        }

        // POST: Boleto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Id,Valor")] Boleto boleto)
        {
            if (id != boleto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletoExists(boleto.Id))
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
            return View(boleto);
        }

        // GET: Boleto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boletos == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // POST: Boleto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boletos == null)
            {
                return Problem("Entity set 'MyDbContext.Boletos'  is null.");
            }
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto != null)
            {
                _context.Boletos.Remove(boleto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletoExists(int id)
        {
          return (_context.Boletos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
