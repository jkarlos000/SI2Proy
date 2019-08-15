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
    public class DetallePedidoesController : Controller
    {
        private readonly ProduccionContext _context;

        public DetallePedidoesController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: DetallePedidoes
        public async Task<IActionResult> Index()
        {
            var produccionContext = _context.DetallePedido.Include(d => d.ModeloProductoFkNavigation).Include(d => d.PedidoFkNavigation);
            return View(await produccionContext.ToListAsync());
        }

        // GET: DetallePedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.ModeloProductoFkNavigation)
                .Include(d => d.PedidoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalle == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidoes/Create
        public IActionResult Create()
        {
            ViewData["ModeloProductoFk"] = new SelectList(_context.ModeloProducto, "CodEstructuraMateria", "CodEstructuraMateria");
            ViewData["PedidoFk"] = new SelectList(_context.Pedido, "NumeroOrdenCompra", "NumeroOrdenCompra");
            return View();
        }

        // POST: DetallePedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDetalle,CantidadDetalle,PrecioTotalDetalle,DetallePedidoFinalizado,PedidoFk,ModeloProductoFk,Digitador,FechaDigitador")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloProductoFk"] = new SelectList(_context.ModeloProducto, "CodEstructuraMateria", "CodEstructuraMateria", detallePedido.ModeloProductoFk);
            ViewData["PedidoFk"] = new SelectList(_context.Pedido, "NumeroOrdenCompra", "NumeroOrdenCompra", detallePedido.PedidoFk);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["ModeloProductoFk"] = new SelectList(_context.ModeloProducto, "CodEstructuraMateria", "CodEstructuraMateria", detallePedido.ModeloProductoFk);
            ViewData["PedidoFk"] = new SelectList(_context.Pedido, "NumeroOrdenCompra", "NumeroOrdenCompra", detallePedido.PedidoFk);
            return View(detallePedido);
        }

        // POST: DetallePedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDetalle,CantidadDetalle,PrecioTotalDetalle,DetallePedidoFinalizado,PedidoFk,ModeloProductoFk,Digitador,FechaDigitador")] DetallePedido detallePedido)
        {
            if (id != detallePedido.CodDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.CodDetalle))
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
            ViewData["ModeloProductoFk"] = new SelectList(_context.ModeloProducto, "CodEstructuraMateria", "CodEstructuraMateria", detallePedido.ModeloProductoFk);
            ViewData["PedidoFk"] = new SelectList(_context.Pedido, "NumeroOrdenCompra", "NumeroOrdenCompra", detallePedido.PedidoFk);
            return View(detallePedido);
        }

        // GET: DetallePedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.ModeloProductoFkNavigation)
                .Include(d => d.PedidoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodDetalle == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            _context.DetallePedido.Remove(detallePedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.CodDetalle == id);
        }
    }
}
