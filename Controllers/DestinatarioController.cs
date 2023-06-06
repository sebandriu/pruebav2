using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demo.Models;

namespace demo.Controllers
{
    public class DestinatarioController : Controller
    {
        private readonly gestion_citasContext _context;

        public DestinatarioController(gestion_citasContext context)
        {
            _context = context;
        }

        // GET: Destinatario
        public async Task<IActionResult> Index()
        {
              return View(await _context.Destinatarios.ToListAsync());
        }

        // GET: Destinatario/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Destinatarios == null)
            {
                return NotFound();
            }

            var destinatario = await _context.Destinatarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinatario == null)
            {
                return NotFound();
            }

            return View(destinatario);
        }

        // GET: Destinatario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinatario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,Telefono,Descripcion")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinatario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinatario);
        }

        // GET: Destinatario/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Destinatarios == null)
            {
                return NotFound();
            }

            var destinatario = await _context.Destinatarios.FindAsync(id);
            if (destinatario == null)
            {
                return NotFound();
            }
            return View(destinatario);
        }

        // POST: Destinatario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nombre,Correo,Telefono,Descripcion")] Destinatario destinatario)
        {
            if (id != destinatario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinatario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinatarioExists(destinatario.Id))
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
            return View(destinatario);
        }

        // GET: Destinatario/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Destinatarios == null)
            {
                return NotFound();
            }

            var destinatario = await _context.Destinatarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destinatario == null)
            {
                return NotFound();
            }

            return View(destinatario);
        }

        // POST: Destinatario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Destinatarios == null)
            {
                return Problem("Entity set 'gestion_citasContext.Destinatarios'  is null.");
            }
            var destinatario = await _context.Destinatarios.FindAsync(id);
            if (destinatario != null)
            {
                _context.Destinatarios.Remove(destinatario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinatarioExists(long id)
        {
          return _context.Destinatarios.Any(e => e.Id == id);
        }
    }
}
