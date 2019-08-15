using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SI2Proy.Models;

namespace SI2Proy.ViewModels
{
    public class OrdenAprovDetalle
    {
        public OrdenAprovisionamiento OrdenAprovisionamientos { get; set; }

        public List<Inventario> Inventarios { get; set; }

        public List<DetalleAprovisionamiento> ListDetalleOrdenAprov { get; set; }

        public DetalleAprovisionamiento Detalle { get; set; }
    }
}
