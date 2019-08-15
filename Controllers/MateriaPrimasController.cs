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
    public class MateriaPrimasController : Controller
    {
        private readonly ProduccionContext _context;

        public MateriaPrimasController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: MateriaPrimas
        public async Task<IActionResult> Index(string searchString)
        {
            var produccionContext = await _context.MateriaPrima.Include(m => m.InsumoFkNavigation).Include(m => m.UnidadMedidaFkNavigation).ToListAsync();
           

            if (!String.IsNullOrEmpty(searchString))
            {
                produccionContext = produccionContext.Where(s => s.Agregado.NombreMateriaPrima.Contains(searchString)).ToList();
            }

            return View(produccionContext);
        }

        // GET: MateriaPrimas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriaPrima
                .Include(m => m.InsumoFkNavigation)
                .Include(m => m.UnidadMedidaFkNavigation)
                .FirstOrDefaultAsync(m => m.CodMateriaPrima == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Create
        public IActionResult Create()
        {
            ViewData["InsumoFk"] = new SelectList(_context.Insumo, "CodInsumo", "NombreInsumo");
            ViewData["UnidadMedidaFk"] = new SelectList(_context.UnidadMedida, "CodUnidadMedida", "NombreUnidadMedida");
            
            return View();
        }

        // POST: MateriaPrimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MateriaPrima materiaPrima)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    materiaPrima.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    materiaPrima.FechaDigitador = DateTime.Now;
                    materiaPrima.FechaCreacion = DateTime.Now;
                    
                }
                _context.Add(materiaPrima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsumoFk"] = new SelectList(_context.Insumo, "CodInsumo", "NombreInsumo", materiaPrima.InsumoFk);
            ViewData["UnidadMedidaFk"] = new SelectList(_context.UnidadMedida, "CodUnidadMedida", "NombreUnidadMedida", materiaPrima.UnidadMedidaFk);
            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriaPrima.FindAsync(id);
            if (materiaPrima == null)
            {
                return NotFound();
            }
            ViewData["InsumoFk"] = new SelectList(_context.Insumo, "CodInsumo", "CodInsumo", materiaPrima.InsumoFk);
            ViewData["UnidadMedidaFk"] = new SelectList(_context.UnidadMedida, "CodUnidadMedida", "CodUnidadMedida", materiaPrima.UnidadMedidaFk);
            return View(materiaPrima);
        }

        // POST: MateriaPrimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MateriaPrima materiaPrima)
        {
            if (id != materiaPrima.CodMateriaPrima)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaPrima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaPrimaExists(materiaPrima.CodMateriaPrima))
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
            ViewData["InsumoFk"] = new SelectList(_context.Insumo, "CodInsumo", "CodInsumo", materiaPrima.InsumoFk);
            ViewData["UnidadMedidaFk"] = new SelectList(_context.UnidadMedida, "CodUnidadMedida", "CodUnidadMedida", materiaPrima.UnidadMedidaFk);
            return View(materiaPrima);
        }

        // GET: MateriaPrimas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrima = await _context.MateriaPrima
                .Include(m => m.InsumoFkNavigation)
                .Include(m => m.UnidadMedidaFkNavigation)
                .FirstOrDefaultAsync(m => m.CodMateriaPrima == id);
            if (materiaPrima == null)
            {
                return NotFound();
            }

            return View(materiaPrima);
        }

        // POST: MateriaPrimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaPrima = await _context.MateriaPrima.FindAsync(id);
            _context.MateriaPrima.Remove(materiaPrima);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaPrimaExists(int id)
        {
            return _context.MateriaPrima.Any(e => e.CodMateriaPrima == id);
        }
    }
}
