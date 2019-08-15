using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SI2Proy.Models;

namespace SI2Proy.Controllers
{
    public class LineaProduccionsController : Controller
    {
        private readonly ProduccionContext _context;

        public LineaProduccionsController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: LineaProduccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.LineaProduccion.ToListAsync());
        }

        // GET: LineaProduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaProduccion = await _context.LineaProduccion
                .FirstOrDefaultAsync(m => m.NumeroLineaProduccion == id);
            if (lineaProduccion == null)
            {
                return NotFound();
            }

            return View(lineaProduccion);
        }

        // GET: LineaProduccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineaProduccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LineaProduccion lineaProduccion)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    lineaProduccion.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    lineaProduccion.FechaDigitador = DateTime.Now;
                    lineaProduccion.FechaCreacion = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
                }
                _context.Add(lineaProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineaProduccion);
        }

        // GET: LineaProduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaProduccion = await _context.LineaProduccion.FindAsync(id);
            if (lineaProduccion == null)
            {
                return NotFound();
            }
            return View(lineaProduccion);
        }

        // POST: LineaProduccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,LineaProduccion lineaProduccion)
        {
            if (id != lineaProduccion.NumeroLineaProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineaProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineaProduccionExists(lineaProduccion.NumeroLineaProduccion))
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
            return View(lineaProduccion);
        }

        // GET: LineaProduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineaProduccion = await _context.LineaProduccion
                .FirstOrDefaultAsync(m => m.NumeroLineaProduccion == id);
            if (lineaProduccion == null)
            {
                return NotFound();
            }

            return View(lineaProduccion);
        }

        // POST: LineaProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineaProduccion = await _context.LineaProduccion.FindAsync(id);
            _context.LineaProduccion.Remove(lineaProduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineaProduccionExists(int id)
        {
            return _context.LineaProduccion.Any(e => e.NumeroLineaProduccion == id);
        }
    }
}
