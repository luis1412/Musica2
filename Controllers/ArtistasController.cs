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
    public class ArtistasController : Controller
    {
        private readonly MyDbContext _context;

        public ArtistasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
              return _context.Artistas != null ? 
                          View(await _context.Artistas.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Artistas'  is null.");
        }

        // GET: Artistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artistas == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistas == null)
            {
                return NotFound();
            }

            return View(artistas);
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,numeroCanciones,oyentesMensuales,Canciones")]
        Artistas artistas)
        {
            _context.Add(artistas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Artistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artistas == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas.FindAsync(id);
            if (artistas == null)
            {
                return NotFound();
            }
            return View(artistas);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
[Bind("Id,Nombre,numeroCanciones,oyentesMensuales,Canciones")] Artistas artistas)
        {
            if (id != artistas.Id)
            {
                return NotFound();
            }
            _context.Update(artistas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Artistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artistas == null)
            {
                return NotFound();
            }

            var artistas = await _context.Artistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artistas == null)
            {
                return NotFound();
            }

            return View(artistas);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artistas == null)
            {
                return Problem("Entity set 'MyDbContext.Artistas'  is null.");
            }
            var artistas = await _context.Artistas.FindAsync(id);
            if (artistas != null)
            {
                _context.Artistas.Remove(artistas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistasExists(int id)
        {
          return (_context.Artistas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
