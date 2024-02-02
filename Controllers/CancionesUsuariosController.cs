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
    public class CancionesUsuariosController : Controller
    {
        private readonly MyDbContext _context;

        public CancionesUsuariosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CancionesUsuarios
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.CancionesUsuarios.Include(c => c.Canciones).Include(c => c.Usuarios);
            return View(await myDbContext.ToListAsync());
        }

        // GET: CancionesUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CancionesUsuarios == null)
            {
                return NotFound();
            }

            var cancionesUsuarios = await _context.CancionesUsuarios
                .Include(c => c.Canciones)
                .Include(c => c.Usuarios)
                .FirstOrDefaultAsync(m => m.UsuariosId == id);
            if (cancionesUsuarios == null)
            {
                return NotFound();
            }

            return View(cancionesUsuarios);
        }

        // GET: CancionesUsuarios/Create
        public IActionResult Create()
        {
            ViewData["CancionesId"] = new SelectList(_context.Canciones, "Id", "Id");
            ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: CancionesUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuarios, Canciones, UsuariosId, CancionesId")]
CancionesUsuarios cancionesUsuarios)
        {
            _context.Add(cancionesUsuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


		// GET: CancionesUsuarios/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.CancionesUsuarios == null)
			{
				return NotFound();
			}
			var estudianteCurso = await _context.CancionesUsuarios.FindAsync(id);

			if (estudianteCurso == null)
			{
				return NotFound();
			}

			ViewData["CancionesId"] = new SelectList(_context.Canciones, "Id", "Id", estudianteCurso.CancionesId);
			ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "Id",
		   estudianteCurso.UsuariosId);
			return View(estudianteCurso);
		}






		// POST: CancionesUsuarios/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,
[Bind("CancionesId,UsuariosId")] CancionesUsuarios estudianteCurso)
		{
			if (id != estudianteCurso.CancionesId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(estudianteCurso);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CancionesUsuariosExists(estudianteCurso.CancionesId))
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
			ViewData["CancionesId"] = new SelectList(_context.Canciones, "Id", "Id", estudianteCurso.CancionesId);
			ViewData["UsuariosId"] = new SelectList(_context.Usuarios, "Id", "Id",
		   estudianteCurso.UsuariosId);
			return View(estudianteCurso);
		}



		// GET: CancionesUsuarios/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CancionesUsuarios == null)
            {
                return NotFound();
            }

            var cancionesUsuarios = await _context.CancionesUsuarios
                .Include(c => c.Canciones)
                .Include(c => c.Usuarios)
                .FirstOrDefaultAsync(m => m.UsuariosId == id);
            if (cancionesUsuarios == null)
            {
                return NotFound();
            }

            return View(cancionesUsuarios);
        }

        // POST: CancionesUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CancionesUsuarios == null)
            {
                return Problem("Entity set 'MyDbContext.CancionesUsuarios'  is null.");
            }
            var cancionesUsuarios = await _context.CancionesUsuarios.FindAsync(id);
            if (cancionesUsuarios != null)
            {
                _context.CancionesUsuarios.Remove(cancionesUsuarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionesUsuariosExists(int id)
        {
          return (_context.CancionesUsuarios?.Any(e => e.UsuariosId == id)).GetValueOrDefault();
        }
    }
}
