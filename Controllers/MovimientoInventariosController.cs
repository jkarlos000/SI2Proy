using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SI2Proy.Models;

namespace SI2Proy.Controllers
{
    public class MovimientoInventariosController : Controller
    {
        private readonly ProduccionContext _context;

        public MovimientoInventariosController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: MovimientoInventarios
        public async Task<IActionResult> Index()
        {
            var produccionContext = _context.MovimientoInventario.Include(m => m.InventarioFkNavigation).Include(m => m.OrdenAprovisionamientoFkNavigation).Include(m => m.ProveedorFkNavigation);
            return View(await produccionContext.ToListAsync());
        }

        // GET: MovimientoInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventario
                .Include(m => m.InventarioFkNavigation)
                .Include(m => m.OrdenAprovisionamientoFkNavigation)
                .Include(m => m.ProveedorFkNavigation)
                .FirstOrDefaultAsync(m => m.CodMovimientoInventario == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Create
        public IActionResult Create()
        {
            ViewData["InventarioFk"] = new SelectList(_context.Inventario, "CodInventario", "CodInventario");
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento, "NumeroOrdenAprovisionamiento", "NumeroOrdenAprovisionamiento");
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NumeroProveedor");
            return View();
        }

        // POST: MovimientoInventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MovimientoInventario movimientoInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventarioFk"] = new SelectList(_context.Inventario, "CodInventario", "CodInventario", movimientoInventario.InventarioFk);
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento, "NumeroOrdenAprovisionamiento", "NumeroOrdenAprovisionamiento", movimientoInventario.OrdenAprovisionamientoFk);
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NumeroProveedor", movimientoInventario.ProveedorFk);
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventario.FindAsync(id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }
            ViewData["InventarioFk"] = new SelectList(_context.Inventario, "CodInventario", "CodInventario", movimientoInventario.InventarioFk);
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento, "NumeroOrdenAprovisionamiento", "NumeroOrdenAprovisionamiento", movimientoInventario.OrdenAprovisionamientoFk);
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NumeroProveedor", movimientoInventario.ProveedorFk);
            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodMovimientoInventario,TipoMovimiento,FechaMovimiento,Factura,PrecioUnitario,Cantidad,Observacion,InventarioFk,ProveedorFk,OrdenAprovisionamientoFk,Digitador,FechaDigitador")] MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.CodMovimientoInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoInventarioExists(movimientoInventario.CodMovimientoInventario))
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
            ViewData["InventarioFk"] = new SelectList(_context.Inventario, "CodInventario", "CodInventario", movimientoInventario.InventarioFk);
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento, "NumeroOrdenAprovisionamiento", "NumeroOrdenAprovisionamiento", movimientoInventario.OrdenAprovisionamientoFk);
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NumeroProveedor", movimientoInventario.ProveedorFk);
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventario
                .Include(m => m.InventarioFkNavigation)
                .Include(m => m.OrdenAprovisionamientoFkNavigation)
                .Include(m => m.ProveedorFkNavigation)
                .FirstOrDefaultAsync(m => m.CodMovimientoInventario == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoInventario = await _context.MovimientoInventario.FindAsync(id);
            _context.MovimientoInventario.Remove(movimientoInventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoInventarioExists(int id)
        {
            return _context.MovimientoInventario.Any(e => e.CodMovimientoInventario == id);
        }
    }
}
