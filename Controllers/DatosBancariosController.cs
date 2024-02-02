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
    public class DatosBancariosController : Controller
    {
        private readonly MyDbContext _context;

        public DatosBancariosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: DatosBancarios
        public async Task<IActionResult> Index()
        {
            return _context.DatosBancarios != null ?
                        View(await _context.DatosBancarios.ToListAsync()) :
                        Problem("Entity set 'MyDbContext.DatosBancarios'  is null.");
        }

        // GET: DatosBancarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DatosBancarios == null)
            {
                return NotFound();
            }

            var datosBancarios = await _context.DatosBancarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosBancarios == null)
            {
                return NotFound();
            }

            return View(datosBancarios);
        }

        // GET: DatosBancarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosBancarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, IBAN, fechaExpiracion, CVV, UsuariosId")]
DatosBancarios estudiante)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DatosBancarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DatosBancarios == null)
            {
                return NotFound();
            }

            var datosBancarios = await _context.DatosBancarios.FindAsync(id);
            if (datosBancarios == null)
            {
                return NotFound();
            }
            return View(datosBancarios);
        }

        // POST: DatosBancarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
 [Bind("Id, IBAN, fechaExpiracion, CVV, UsuariosId")] DatosBancarios estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }
            _context.Update(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: DatosBancarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DatosBancarios == null)
            {
                return NotFound();
            }

            var datosBancarios = await _context.DatosBancarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datosBancarios == null)
            {
                return NotFound();
            }

            return View(datosBancarios);
        }

        // POST: DatosBancarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DatosBancarios == null)
            {
                return Problem("Entity set 'MyDbContext.DatosBancarios'  is null.");
            }
            var datosBancarios = await _context.DatosBancarios.FindAsync(id);
            if (datosBancarios != null)
            {
                _context.DatosBancarios.Remove(datosBancarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosBancariosExists(int id)
        {
            return (_context.DatosBancarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
