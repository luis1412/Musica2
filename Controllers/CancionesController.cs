using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musica2.Context;
using Musica2.Models;

namespace Musica2.Controllers
{
    public class CancionesController : Controller
    {
        private readonly MyDbContext _context;

        public CancionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Canciones
        public async Task<IActionResult> Index()
        {
              return _context.Canciones != null ? 
                          View(await _context.Canciones.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Canciones'  is null.");
        }

        // GET: Canciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canciones == null)
            {
                return NotFound();
            }

            return View(canciones);
        }

        // GET: Canciones/Create
        public IActionResult Create()
        {
            ViewData["ArtistasId"] = new SelectList(_context.Artistas, "Id", "Id");
            return View();
        }

        // POST: Canciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, nombre, descripcion, ArtistasId, CancionesUsuarios")]
Canciones canciones)
        {
            _context.Add(canciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Canciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones.FindAsync(id);
            if (canciones == null)
            {
                return NotFound();
            }
            return View(canciones);
        }

        // POST: Canciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
[Bind("Id, nombre, descripcion, ArtistasId, CancionesUsuarios")] Canciones canciones)
        {
            if (id != canciones.Id)
            {
                return NotFound();
            }
            _context.Update(canciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Canciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canciones == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canciones == null)
            {
                return NotFound();
            }

            ViewData["ArtistasId"] = new SelectList(_context.Artistas, "Id",
            "Id", canciones.ArtistasId);
            return View(canciones);
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canciones == null)
            {
                return Problem("Entity set 'MyDbContext.Canciones'  is null.");
            }
            var canciones = await _context.Canciones.FindAsync(id);
            if (canciones != null)
            {
                _context.Canciones.Remove(canciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionesExists(int id)
        {
          return (_context.Canciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
