using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SI2Proy.Models;
using SI2Proy.ViewModels;

namespace SI2Proy.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly ProduccionContext _context;

        public PedidoesController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index(string searchString)
        {
            var produccionContext = await _context.Pedido.Include(p => p.ClienteFkNavigation).Include(p => p.VendedorFkNavigation).ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                produccionContext = produccionContext.Where(s => s.ClienteFkNavigation.Persona.NombreCliente.Contains(searchString)).ToList();
            }

            return View(produccionContext);
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.ClienteFkNavigation)
                .Include(p => p.VendedorFkNavigation)
                .FirstOrDefaultAsync(m => m.NumeroOrdenCompra == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            // ViewData["ClienteFk"] = new SelectList(_context.Cliente, "NumeroCliente", "NumeroCliente");
            ViewData["ClienteFk"] = new SelectList(_context.Persona, "NumeroCliente", "NombreCliente");
          //  ViewData["ClienteFk"] = new SelectList(_context.Cliente, "NumeroCliente", "NumeroCliente");
            ViewData["VendedorFk"] = new SelectList(_context.Vendedor, "NumeroVendedor", "NombreVendedor");
            var listModelProducto = _context.ModeloProducto.AsNoTracking().ToList();
            //var listto = listModelProducto;
            
            return View(listModelProducto);
        }

        [HttpPost]
        public ActionResult SaveOrder([FromBody]PedidosView obsT)
        {
            var numeroNota = _context.Pedido.AsNoTracking().ToList();
            string result = "Error! Order Is Not Complete!";
            Pedido orD = new Pedido();
            List<DetallePedido> ListDetalle = new List<DetallePedido>();
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    orD.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    orD.FechaDigitador = DateTime.Now;
                    orD.FechaEntrega = obsT.FechaEntrega;
                    orD.ClienteFk = obsT.NumeroCliente;
                    orD.VendedorFk = obsT.NumeroVendedor;
                    orD.PedidoFinalizado = false;
                    orD.NumeroNotaPedido = string.Concat("N-", numeroNota.Count+1);
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
                }
                //orD.FechaEntrega = obsT.FechaEntrega;
                //orD.FechaEstimadaEntrega = obsT.FechaEstimadaEntrega;
                orD.Observaciones = obsT.Observaciones;
                int cantidadTotal = 0;
                int precioTotal = 0;
                int precioU = 0;
                foreach (var item in obsT.detalle)
                {
                    precioU = item.PrecioUnitario;
                    ListDetalle.Add(new DetallePedido()
                    {
                        CantidadDetalle=item.stock,
                        PrecioTotalDetalle= precioU * item.stock,
                        ModeloProductoFk= item.idInventario,
                        DetallePedidoFinalizado=false,
                        Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        FechaDigitador=DateTime.Now
                    });
                    cantidadTotal = cantidadTotal + item.stock;
                    precioTotal = precioTotal + (precioU * item.stock);
                }
                orD.PrecioTotal = precioTotal;
                orD.Cantidad = cantidadTotal;
                orD.DetallePedido = ListDetalle;
                _context.Pedido.Add(orD);
                _context.SaveChanges();

                //ordenAprovisionamientosD.OrdenAprovisionamientos.DetalleAprovisionamiento = ordenAprovisionamientosD.ListDetalleOrdenAprov;
                //_context.Add(ordenAprovisionamientosD.OrdenAprovisionamientos);

                //await _context.SaveChangesAsync();
                result = "Guardado con exito!";
                return Json(result);
            }


            return Json(result);
        }
        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteFk"] = new SelectList(_context.Cliente, "NumeroCliente", "NumeroCliente", pedido.ClienteFk);
            ViewData["VendedorFk"] = new SelectList(_context.Vendedor, "NumeroVendedor", "NumeroVendedor", pedido.VendedorFk);
            ViewData["Pedidos"] = new SelectList(_context.ModeloProducto, "CodigoProducto", "NombreModelo", pedido.VendedorFk);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ClienteFk"] = new SelectList(_context.Cliente, "NumeroCliente", "NumeroCliente", pedido.ClienteFk);
            ViewData["VendedorFk"] = new SelectList(_context.Vendedor, "NumeroVendedor", "NumeroVendedor", pedido.VendedorFk);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.NumeroOrdenCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.NumeroOrdenCompra))
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
            ViewData["ClienteFk"] = new SelectList(_context.Persona, "NumeroCliente", "NombreCliente", pedido.ClienteFk);
            ViewData["VendedorFk"] = new SelectList(_context.Vendedor, "NumeroVendedor", "NumeroVendedor", pedido.VendedorFk);
            return View(pedido);
        }

        public async Task<IActionResult> Aprobar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        public IActionResult Aprobar(int id)
        {
            var Pedido = _context.Pedido.Find(id);
            var ListPedido = _context.DetallePedido.Where(i => i.PedidoFk == id).ToList();
            //var ListDetalle = _context.DetalleAprovisionamiento.ToList();
            foreach (var item in ListPedido)
            {
                item.DetallePedidoFinalizado = true;
                
            }
            Pedido.FechaRealEntregaPedido = DateTime.Now;
            Pedido.PedidoFinalizado = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            //return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.ClienteFkNavigation)
                .Include(p => p.VendedorFkNavigation)
                .FirstOrDefaultAsync(m => m.NumeroOrdenCompra == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.NumeroOrdenCompra == id);
        }
    }
}
