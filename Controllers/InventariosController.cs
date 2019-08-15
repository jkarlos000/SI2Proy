using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SI2Proy.Models;


namespace SI2Proy.Controllers
{
    public class InventariosController : Controller
    {
        private readonly ProduccionContext _context;
       // private readonly UserManager<ApplicationUser> _userManager;

        public InventariosController(ProduccionContext context )
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
            var produccionContext = _context.Inventario
                .Include(i => i.AgregadoFkNavigation)
                .ThenInclude(j => j.CodMateriaPrimaNavigation)
                .ThenInclude(k => k.UnidadMedidaFkNavigation);
            return View(await produccionContext.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.AgregadoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            ViewData["AgregadoFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "NombreMateriaPrima");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    inventario.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    inventario.FechaDigitador = DateTime.Now;
                    
                }
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgregadoFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "CodMateriaPrima", inventario.AgregadoFk);
            return View(inventario);
        }

        public IActionResult EgresoMateriaPrima()
        {
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NombreProveedor");
            ViewData["InventarioFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "NombreMateriaPrima");

            //var listInventario = _context.Inventario;
            return View();
        }

        [HttpPost]
        public IActionResult EgresoMateriaPrima(MovimientoInventario movimientoInventario)
        {
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NombreProveedor");
            ViewData["InventarioFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "NombreMateriaPrima");

            var listInventario = _context.Inventario.Where(i => i.AgregadoFk == movimientoInventario.InventarioFk).FirstOrDefault();
            
            Random ran = new Random();
            if (movimientoInventario.Cantidad < listInventario.Total)
            {


                if (ModelState.IsValid)
                {
                    listInventario.Total = listInventario.Total - movimientoInventario.Cantidad;
                    movimientoInventario.InventarioFk = listInventario.CodInventario;

                    if (User.Identity.IsAuthenticated)
                    {
                        movimientoInventario.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        movimientoInventario.FechaDigitador = DateTime.Now;
                        movimientoInventario.FechaMovimiento = DateTime.Now;
                        movimientoInventario.TipoMovimiento = "E";
                    }
                    //  movimientoInventario.Factura = ran.Next(20, 100).ToString();
                    // movimientoInventario.PrecioUnitario = ran.Next(20, 100);
                    _context.Add(movimientoInventario);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
          //  var listInventarios = _context.Inventario;
            return View();
        }

        public IActionResult CrearAsociacion()
        {
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NombreProveedor");
            var listMats = _context.Agregado;
            var listInventario = _context.Inventario;
            List<Agregado> liA = new List<Agregado>();
            bool MatsInven = true;
            
            foreach (var item in listMats)
            {

                foreach (var liMats in listInventario)
                {
                    if (item.CodMateriaPrima== liMats.AgregadoFk)
                    {
                        MatsInven = false;
                    }
                }

                    if (MatsInven)
                    {
                          liA.Add(new Agregado()
                        {
                        NombreMateriaPrima = item.NombreMateriaPrima,
                        CodMateriaPrima = item.CodMateriaPrima
                        });
                    }

                MatsInven = true;
            }
            ViewData["AgregadoFk"] = new SelectList(liA, "CodMateriaPrima", "NombreMateriaPrima");

            //var listInventario = _context.Inventario;
            return View();
        }

        [HttpPost]
        public IActionResult CrearAsociacion(int AgregadoFk)
        {
            Inventario nuevo = new Inventario();
            if (ModelState.IsValid)
            {
                nuevo.AgregadoFk = AgregadoFk;
                if (User.Identity.IsAuthenticated)
                {
                    nuevo.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    nuevo.FechaDigitador = DateTime.Now;
                    
                }
                nuevo.Total = 0;
                _context.Inventario.Add(nuevo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
                return View();
        }

        public IActionResult EliminarAsociacion()
        {
            var listE = _context.Inventario.Where(i => i.Total == 0).ToList();
            var listMats = _context.Agregado.ToList();

          //  ViewData["InventarioFk"] = new SelectList(, "CodInventario", "NombreProveedor");
            
            List<Agregado> liA = new List<Agregado>();
            bool MatsInven = false;

            foreach (var item in listMats)
            {

                foreach (var liMats in listE)
                {
                    if (item.CodMateriaPrima == liMats.AgregadoFk)
                    {
                        MatsInven = true;
                    }
                }

                if (MatsInven)
                {
                    liA.Add(new Agregado()
                    {
                        NombreMateriaPrima = item.NombreMateriaPrima,
                        CodMateriaPrima = item.CodMateriaPrima
                    });
                }

                MatsInven = false;
            }
            ViewData["AgregadoFk"] = new SelectList(liA, "CodMateriaPrima", "NombreMateriaPrima");

            //var listInventario = _context.Inventario;
            return View();
        }

        [HttpPost]
        public IActionResult EliminarAsociacion(int AgregadoFk)
        {
            var inventarioRemover = _context.Inventario.Find(AgregadoFk);
            if (ModelState.IsValid)
            {
                
                _context.Inventario.Remove(inventarioRemover);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult IngresoMateriaPrima()
        {
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NombreProveedor");
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento.Where(i=>i.EstadoEntregado==false), "NumeroOrdenAprovisionamiento", "FechaEstimadaEntrega");

            
            return View();
        }

        [HttpPost]
        public IActionResult IngresoMateriaPrima(MovimientoInventario movimientoInventario)
        {
            if (ModelState.IsValid)
            {
                List<MovimientoInventario> listMov = new List<MovimientoInventario>();
                if (User.Identity.IsAuthenticated)
                {
                    movimientoInventario.Digitador = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    movimientoInventario.FechaDigitador = DateTime.Now;

                }

                var detalleOrdenAprov = _context.DetalleAprovisionamiento
                    .Include(j=>j.InventarioFkNavigation)
                    .Where(i => i.OrdenAprovisionamientoFk == movimientoInventario.OrdenAprovisionamientoFk).ToList();
                Random ran = new Random();

                var aumentar = _context.Inventario.ToList();

                foreach (var item in detalleOrdenAprov)
                {
                    listMov.Add(new MovimientoInventario()
                    {
                        Cantidad=item.Cantidad,
                        PrecioUnitario=ran.Next(20,100),
                        Digitador= movimientoInventario.Digitador,
                        FechaDigitador= movimientoInventario.FechaDigitador,
                        FechaMovimiento=DateTime.Now,
                        Factura= ran.Next(20, 100).ToString(),
                        Observacion= movimientoInventario.Observacion,
                        OrdenAprovisionamientoFk=movimientoInventario.OrdenAprovisionamientoFk,
                        ProveedorFk=movimientoInventario.ProveedorFk,
                        TipoMovimiento="I",
                        InventarioFk=item.InventarioFk                        
                    });

                    item.InventarioFkNavigation.Total = item.InventarioFkNavigation.Total + item.Cantidad;

                }

                var ordenAp = _context.OrdenAprovisionamiento.Find(movimientoInventario.OrdenAprovisionamientoFk);
                var ListDet = _context.DetalleAprovisionamiento.Where(i => i.OrdenAprovisionamientoFk == movimientoInventario.OrdenAprovisionamientoFk).ToList();


                //var ListDetalle = _context.DetalleAprovisionamiento.ToList();
                foreach (var item in ListDet)
                {
                    item.Ingresado = true;
                }
                ordenAp.FechaEntrega = DateTime.Now;
                ordenAp.EstadoEntregado = true;

                foreach (var item in listMov)
                {
                    _context.Add(item);
                }

               // movimientoInventario.Cantidad

               // _context.Add(movimientoInventario);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProveedorFk"] = new SelectList(_context.Proveedor, "NumeroProveedor", "NombreProveedor");
            ViewData["OrdenAprovisionamientoFk"] = new SelectList(_context.OrdenAprovisionamiento.Where(i => i.EstadoEntregado == false), "NumeroOrdenAprovisionamiento", "FechaEstimadaEntrega");

           // return View(inventario);

            return View();
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["AgregadoFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "CodMateriaPrima", inventario.AgregadoFk);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Inventario inventario)
        {
            if (id != inventario.CodInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.CodInventario))
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
            ViewData["AgregadoFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "CodMateriaPrima", inventario.AgregadoFk);
            return View(inventario);
        }

        public IActionResult ModificarCriteriosStock(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = _context.Inventario.Find(id);
            if (inventario == null)
            {
                return NotFound();
            }
            
            return View(inventario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarCriteriosStock(int id, Inventario inventario)
        {
            if (id != inventario.CodInventario)
            {
                return NotFound();
            }
            var InvList = _context.Inventario.Find(id);


            if (ModelState.IsValid)
            {
                try
                {
                    InvList.StockMaximo = inventario.StockMaximo;
                    InvList.PedirQ = inventario.PedirQ;
                    InvList.SaldoPro = inventario.SaldoPro;
                   // _context.Update(inventario);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.CodInventario))
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
            ViewData["AgregadoFk"] = new SelectList(_context.Agregado, "CodMateriaPrima", "CodMateriaPrima", inventario.AgregadoFk);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.AgregadoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventario.FindAsync(id);
            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventario.Any(e => e.CodInventario == id);
        }

        public int CalculoDelLoteEconomicoDeCompra(int? id, DateTime FechaAnterior)
        {
            //Q= Lote Economico de Compra
            //D= demanda de consumo de materias primas.
            //S= costo de adquisición de cada materia prima
            //I= Interes Anual de  lo Invertido
            //C= precio unitario de cada materia prima ingresada en el inventario

            //Calculo de D  "revisar todas las materias primas del inventario, su historico"
            DateTime FechaActual = DateTime.Now.Date;
            int diferenciaDeFechas = (FechaActual - FechaAnterior).Days;
            //cantidad de materias sacadas en X fecha
            var MovimientoInv = _context.MovimientoInventario.Where(i => i.InventarioFk == id).ToList();
            var MatsEgresadas = MovimientoInv.Where(i => i.TipoMovimiento == "E").ToList();
            var MatsEgresadasMayorAFecha = MatsEgresadas.Where(i => i.FechaMovimiento > FechaAnterior).ToList();
            int cantMats = 0;
            foreach (var item in MatsEgresadasMayorAFecha)
            {
                cantMats = cantMats + (int)item.Cantidad;
            }
            int promedioMats = cantMats / MatsEgresadasMayorAFecha.Count;   //Revisar por si no funciona

            // y = mx + b

           // var q = Math.Sqrt(2*)


                return 0;
        }
    }
}
