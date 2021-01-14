
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajoFinal.Data;
using TrabajoFinal.Models;

namespace TrabajoFinal.Controllers
{
    public class FrutasController : Controller
    {
        private readonly FrutaContexto _context;

        public FrutasController(FrutaContexto context)
        {
            _context = context;
        }

        // GET: Frutas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fruta.ToListAsync());
        }

        // GET: Frutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruta = await _context.Fruta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruta == null)
            {
                return NotFound();
            }

            return View(fruta);
        }

        // GET: Frutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Caducidad,Color,Price")] Fruta fruta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fruta);
        }

        // GET: Frutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruta = await _context.Fruta.FindAsync(id);
            if (fruta == null)
            {
                return NotFound();
            }
            return View(fruta);
        }

        // POST: Frutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Caducidad,Color,Price")] Fruta fruta)
        {
            if (id != fruta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fruta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrutaExists(fruta.Id))
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
            return View(fruta);
        }

        // GET: Frutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruta = await _context.Fruta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruta == null)
            {
                return NotFound();
            }

            return View(fruta);
        }

        // POST: Frutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fruta = await _context.Fruta.FindAsync(id);
            _context.Fruta.Remove(fruta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrutaExists(int id)
        {
            return _context.Fruta.Any(e => e.Id == id);
        }
    }
}
