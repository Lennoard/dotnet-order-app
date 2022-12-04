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
    public class CartaoController : Controller
    {
        private readonly MyDbContext _context;

        public CartaoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Cartao
        public async Task<IActionResult> Index()
        {
              return _context.Cartoes != null ? 
                          View(await _context.Cartoes.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Cartoes'  is null.");
        }

        // GET: Cartao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cartoes == null)
            {
                return NotFound();
            }

            var cartaoDeCredito = await _context.Cartoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaoDeCredito == null)
            {
                return NotFound();
            }

            return View(cartaoDeCredito);
        }

        // GET: Cartao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Id,Valor")] CartaoDeCredito cartaoDeCredito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartaoDeCredito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartaoDeCredito);
        }

        // GET: Cartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cartoes == null)
            {
                return NotFound();
            }

            var cartaoDeCredito = await _context.Cartoes.FindAsync(id);
            if (cartaoDeCredito == null)
            {
                return NotFound();
            }
            return View(cartaoDeCredito);
        }

        // POST: Cartao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,Id,Valor")] CartaoDeCredito cartaoDeCredito)
        {
            if (id != cartaoDeCredito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaoDeCredito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoDeCreditoExists(cartaoDeCredito.Id))
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
            return View(cartaoDeCredito);
        }

        // GET: Cartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cartoes == null)
            {
                return NotFound();
            }

            var cartaoDeCredito = await _context.Cartoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaoDeCredito == null)
            {
                return NotFound();
            }

            return View(cartaoDeCredito);
        }

        // POST: Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cartoes == null)
            {
                return Problem("Entity set 'MyDbContext.Cartoes'  is null.");
            }
            var cartaoDeCredito = await _context.Cartoes.FindAsync(id);
            if (cartaoDeCredito != null)
            {
                _context.Cartoes.Remove(cartaoDeCredito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoDeCreditoExists(int id)
        {
          return (_context.Cartoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
