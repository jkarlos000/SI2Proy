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
    public class ModeloProductoesController : Controller
    {
        private readonly ProduccionContext _context;

        public ModeloProductoesController(ProduccionContext context)
        {
            _context = context;
        }

        // GET: ModeloProductoes
        public async Task<IActionResult> Index()
        {
            var produccionContext = _context.ModeloProducto.Include(m => m.LineaProduccionFkNavigation);
            return View(await produccionContext.ToListAsync());
        }

        // GET: ModeloProductoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mats = _context.EstructuraMaterialesBom
                .Include(i => i.MateriaPrimaFkNavigation)
                .ThenInclude(j=>j.InsumoFkNavigation)
                .Include(i => i.MateriaPrimaFkNavigation)
                .ThenInclude(j => j.UnidadMedidaFkNavigation)
                .Include(i=>i.MateriaPrimaFkNavigation)
                .ThenInclude(b=>b.Agregado)
                .Where(a => a.ModeloProductoFk == id).ToList();
            var modeloProducto = _context.ModeloProducto
                .Include(n=>n.LineaProduccionFkNavigation)
                .Include(j=>j.EstructuraMaterialesBom)
                .FirstOrDefault(m => m.CodEstructuraMateria == id); 
            ModeloProductoView listP = new ModeloProductoView()
            {
                listMats = mats,
                Productos = modeloProducto
            };
            
               // .FirstOrDefaultAsync(m => m.CodEstructuraMateria == id);
            if (listP == null)
            {
                return NotFound();
            }

            return View(listP);
        }

        // GET: ModeloProductoes/Create
        public IActionResult Create()
        {
            ViewData["LineaProduccionFk"] = new SelectList(_context.LineaProduccion, "NumeroLineaProduccion", "NombreLineaProduccion");
            var mats = _context.EstructuraMaterialesBom
                 .Include(i => i.MateriaPrimaFkNavigation)
                 .ThenInclude(j => j.InsumoFkNavigation)
                 .Include(i => i.MateriaPrimaFkNavigation)
                 .ThenInclude(j => j.UnidadMedidaFkNavigation)
                 .Include(i => i.MateriaPrimaFkNavigation)
                 .ThenInclude(b => b.Agregado)
                 .ToList();
            var modeloProducto = _context.ModeloProducto
                .Include(n => n.LineaProduccionFkNavigation)
                .Include(j => j.EstructuraMaterialesBom)
                .ToList();
            var matL = _context.MateriaPrima
                .Include(i=>i.Agregado)
                .Include(j=>j.InsumoFkNavigation)
                .Include(k=>k.UnidadMedidaFkNavigation)
                .ToList();
            //ModelProductCreateView listP = new ModelProductCreateView()
            //{
            //    ListMats
            //    listMats = mats,
            //    Productos = modeloProducto
            //};

            // ViewData["InsumoFk"] = new SelectList(_context.Insumo, "CodInsumo", "NombreInsumo");
            return View(matL);
        }
        [HttpPost]
        public ActionResult SaveOrder([FromBody]SaveModelProductView saveModelProductView)
        {
            string result = "Error! Order Is Not Complete!";
            ModeloProducto orD = new ModeloProducto();
            List<EstructuraMaterialesBom> ListDetalle = new List<EstructuraMaterialesBom>();
           // List<EstructuraMaterialesBom> LMats = new List<EstructuraMaterialesBom>();
           // LMats.Add(new EstructuraMaterialesBom() { Descripcion = "Practica" });

            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    orD.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    orD.FechaDigitador = DateTime.Now;
                   
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaDigitador = DateTime.Now;
                    //ordenAprovisionamientosD.OrdenAprovisionamientos.FechaEmision = DateTime.Now;
                }
                //orD.FechaEntrega = obsT.FechaEntrega;
                //orD.FechaEstimadaEntrega = obsT.FechaEstimadaEntrega;
                orD.Observaciones = saveModelProductView.Observaciones;
                orD.CodigoProducto = saveModelProductView.CodigoProducto;
                orD.Estado = saveModelProductView.Estado;
                orD.LineaProduccionFk = saveModelProductView.LineaProduccionFk;
                orD.NombreModelo = saveModelProductView.NombreModelo;
                orD.PrecioUnitario = saveModelProductView.PrecioUnitario;
                
                foreach (var item in saveModelProductView.detalle)
                {
                    ListDetalle.Add(new EstructuraMaterialesBom()
                    {
                        CantidadPorProducto = item.stock,
                        Descripcion = item.Descripcion,
                        FechaVigencia = item.FechaVigencia,
                        MateriaPrimaFk = item.idMateriaPrima,
                        Obligatorio = true,
                        Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        FechaDigitador = DateTime.Now
                    });
                   
                }
                orD.EstructuraMaterialesBom = ListDetalle;
                _context.ModeloProducto.Add(orD);
                _context.SaveChanges();

                //ordenAprovisionamientosD.OrdenAprovisionamientos.DetalleAprovisionamiento = ordenAprovisionamientosD.ListDetalleOrdenAprov;
                //_context.Add(ordenAprovisionamientosD.OrdenAprovisionamientos);

                //await _context.SaveChangesAsync();
                result = "Guardado con exito!";
                return Json(result);
            }


            return Json(result);
        }

        // POST: ModeloProductoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstructuraMateria,CodigoProducto,NombreModelo,TamanoEstandar,PrecioUnitario,Observaciones,Estado,LineaProduccionFk,Digitador,FechaDigitador")] ModeloProducto modeloProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineaProduccionFk"] = new SelectList(_context.LineaProduccion, "NumeroLineaProduccion", "NumeroLineaProduccion", modeloProducto.LineaProduccionFk);
            return View(modeloProducto);
        }

        // GET: ModeloProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloProducto = await _context.ModeloProducto.FindAsync(id);
            if (modeloProducto == null)
            {
                return NotFound();
            }
            ViewData["LineaProduccionFk"] = new SelectList(_context.LineaProduccion, "NumeroLineaProduccion", "NumeroLineaProduccion", modeloProducto.LineaProduccionFk);
            return View(modeloProducto);
        }

        // POST: ModeloProductoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEstructuraMateria,CodigoProducto,NombreModelo,TamanoEstandar,PrecioUnitario,Observaciones,Estado,LineaProduccionFk,Digitador,FechaDigitador")] ModeloProducto modeloProducto)
        {
            if (id != modeloProducto.CodEstructuraMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductoExists(modeloProducto.CodEstructuraMateria))
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
            ViewData["LineaProduccionFk"] = new SelectList(_context.LineaProduccion, "NumeroLineaProduccion", "NumeroLineaProduccion", modeloProducto.LineaProduccionFk);
            return View(modeloProducto);
        }

        // GET: ModeloProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloProducto = await _context.ModeloProducto
                .Include(m => m.LineaProduccionFkNavigation)
                .FirstOrDefaultAsync(m => m.CodEstructuraMateria == id);
            if (modeloProducto == null)
            {
                return NotFound();
            }

            return View(modeloProducto);
        }

        // POST: ModeloProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloProducto = await _context.ModeloProducto.FindAsync(id);
            _context.ModeloProducto.Remove(modeloProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductoExists(int id)
        {
            return _context.ModeloProducto.Any(e => e.CodEstructuraMateria == id);
        }
    }
}
