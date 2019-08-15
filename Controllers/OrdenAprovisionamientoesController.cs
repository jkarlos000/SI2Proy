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

   
    public class OrdenAprovisionamientoesController : Controller
    {
        private readonly ProduccionContext _context;

        public OrdenAprovisionamientoesController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: OrdenAprovisionamientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdenAprovisionamiento.ToListAsync());
        }

        // GET: OrdenAprovisionamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenAprovisionamiento = await _context.OrdenAprovisionamiento.Include(dO=>dO.DetalleAprovisionamiento)
                .FirstOrDefaultAsync(m => m.NumeroOrdenAprovisionamiento == id);
            if (ordenAprovisionamiento == null)
            {
                return NotFound();
            }

            return View(ordenAprovisionamiento);
        }

        public JsonResult GetInventarios()
        {
            List<Inventario> inventarios = new List<Inventario>();

            inventarios = _context.Inventario.Include(i => i.AgregadoFkNavigation)
                        .ThenInclude(um => um.CodMateriaPrimaNavigation)
                        .ThenInclude(insu => insu.InsumoFkNavigation)
                    .Include(j => j.AgregadoFkNavigation)
                    .ThenInclude(mp => mp.CodMateriaPrimaNavigation)
                    .ThenInclude(medidas => medidas.UnidadMedidaFkNavigation)
                    .ToList();
           
            return new JsonResult(inventarios);
        }

        // GET: OrdenAprovisionamientoes/Create
        public IActionResult Create()
        {
            //OrdenAprovDetalle ordenAprovDetalle = new OrdenAprovDetalle
            //{
            //    Inventarios = _context.Inventario.Include(i => i.AgregadoFkNavigation)
            //            .ThenInclude(um => um.CodMateriaPrimaNavigation)
            //            .ThenInclude(insu => insu.InsumoFkNavigation)
            //        .Include(j => j.AgregadoFkNavigation)
            //        .ThenInclude(mp => mp.CodMateriaPrimaNavigation)
            //        .ThenInclude(medidas => medidas.UnidadMedidaFkNavigation)
            //        .ToList(),
            ////_context.Inventario.Include(i => i.AgregadoFkNavigation).ThenInclude(ma=>ma.CodMateriaPrimaNavigation).ThenInclude(um=>um.UnidadMedidaFkNavigation).Include(m=>m.AgregadoFkNavigation.CodMateriaPrimaNavigation.UnidadMedidaFkNavigation).ToList(),
            //OrdenAprovisionamientos = new OrdenAprovisionamiento(),
            //    ListDetalleOrdenAprov= new List<DetalleAprovisionamiento>()
            //};
            var Inventarios = _context.Inventario.Include(i => i.AgregadoFkNavigation)
                        .ThenInclude(um => um.CodMateriaPrimaNavigation)
                        .ThenInclude(insu => insu.InsumoFkNavigation)
                    .Include(j => j.AgregadoFkNavigation)
                    .ThenInclude(mp => mp.CodMateriaPrimaNavigation)
                    .ThenInclude(medidas => medidas.UnidadMedidaFkNavigation)
                    .ToList();
            ViewBag.ListOfInventario = Inventarios;
            return View(Inventarios);
        }

        // POST: OrdenAprovisionamientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult SaveOrder([FromBody]nofuncion obsT)
        {
            string result = "Error! Order Is Not Complete!";
            OrdenAprovisionamiento orD = new OrdenAprovisionamiento();
            List<DetalleAprovisionamiento> ListDetalle = new List<DetalleAprovisionamiento>();
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    orD.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    orD.FechaDigitador = DateTime.Now;
                    orD.FechaEmision = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
                }
                //orD.FechaEntrega = obsT.FechaEntrega;
                //orD.FechaEstimadaEntrega = obsT.FechaEstimadaEntrega;
                orD.Observacion = obsT.ObservacionOrden;
                
                foreach (var item in obsT.detalle)
                {
                    ListDetalle.Add(new DetalleAprovisionamiento()
                    {
                        Cantidad = item.Cantidad,
                        InventarioFk = item.InventarioFk,
                        Observacion = item.Observacion,
                        Ingresado = false
                    });
                }
                orD.DetalleAprovisionamiento = ListDetalle;
                _context.OrdenAprovisionamiento.Add(orD);
                 _context.SaveChanges();

                //ordenAprovisionamientosD.OrdenAprovisionamientos.DetalleAprovisionamiento = ordenAprovisionamientosD.ListDetalleOrdenAprov;
                //_context.Add(ordenAprovisionamientosD.OrdenAprovisionamientos);

                //await _context.SaveChangesAsync();
                result = "Guardado con exito!";
                return Json(result);
            }

           
            return Json(result);
        }
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public ActionResult Create(string observacion, DetalleAprovisionamiento[] detalleAprovisionamientoL)
        {
            //var b = observacion;
            var a = detalleAprovisionamientoL;
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
                }
                //ordenAprovisionamientosD.OrdenAprovisionamientos.DetalleAprovisionamiento = ordenAprovisionamientosD.ListDetalleOrdenAprov;
                //_context.Add(ordenAprovisionamientosD.OrdenAprovisionamientos);

                //await _context.SaveChangesAsync();

                return Json(nameof(Index));
            }
            return Json(new { success=true,html="",message="Submitted Successfully"});
        }

        // GET: OrdenAprovisionamientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenAprovisionamiento = await _context.OrdenAprovisionamiento.FindAsync(id);
            if (ordenAprovisionamiento == null)
            {
                return NotFound();
            }
            return View(ordenAprovisionamiento);
        }

        // POST: OrdenAprovisionamientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OrdenAprovisionamiento ordenAprovisionamiento)
        {
            if (id != ordenAprovisionamiento.NumeroOrdenAprovisionamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenAprovisionamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenAprovisionamientoExists(ordenAprovisionamiento.NumeroOrdenAprovisionamiento))
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
            return View(ordenAprovisionamiento);
        }

        // GET: OrdenAprovisionamientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenAprovisionamiento = await _context.OrdenAprovisionamiento
                .FirstOrDefaultAsync(m => m.NumeroOrdenAprovisionamiento == id);
            if (ordenAprovisionamiento == null)
            {
                return NotFound();
            }

            return View(ordenAprovisionamiento);
        }

        

        // POST: OrdenAprovisionamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenAprovisionamiento = await _context.OrdenAprovisionamiento.FindAsync(id);
            _context.OrdenAprovisionamiento.Remove(ordenAprovisionamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Aprobar(int? id)
        {
            var ordenAprovisionamiento = _context.OrdenAprovisionamiento
                 .FirstOrDefault(m => m.NumeroOrdenAprovisionamiento == id);
            return View(ordenAprovisionamiento);
        }

        [HttpPost,ActionName("Aprobar")]
        public IActionResult Aprobar(int id, DateTime FechaEstimadaEntrega)
        {
            var ordenAprov = _context.OrdenAprovisionamiento.Find(id);
            ordenAprov.Aprobado = true;
            ordenAprov.FechaEstimadaEntrega = FechaEstimadaEntrega;

            if (User.Identity.IsAuthenticated)
            {
                var nameApro = User.FindFirst(ClaimTypes.Name).Value;

                ordenAprov.AprobadoPor = nameApro;
                //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
            }
          
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EstadoEntregado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenAprovisionamiento =  _context.OrdenAprovisionamiento
                .FirstOrDefault(m => m.NumeroOrdenAprovisionamiento == id);
            if (ordenAprovisionamiento == null)
            {
                return NotFound();
            }

            return View(ordenAprovisionamiento);
        }

        [HttpPost]
        public IActionResult EstadoEntregado(int id)
        {
            var ordenAp = _context.OrdenAprovisionamiento.Find(id);
            var ListDet = _context.DetalleAprovisionamiento.Where(i => i.OrdenAprovisionamientoFk == id).ToList();
               

            //var ListDetalle = _context.DetalleAprovisionamiento.ToList();
            foreach (var item in ListDet)
            {
                item.Ingresado = true;
            }
            ordenAp.FechaEntrega = DateTime.Now;
            ordenAp.EstadoEntregado = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenAprovisionamientoExists(int id)
        {
            return _context.OrdenAprovisionamiento.Any(e => e.NumeroOrdenAprovisionamiento == id);
        }
    }
}
