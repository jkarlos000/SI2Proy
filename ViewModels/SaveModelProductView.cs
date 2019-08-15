using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SI2Proy.ViewModels
{
    public class SaveModelProductView
    {
        public int LineaProduccionFk { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreModelo { get; set; }
        public int PrecioUnitario { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
        public List<MaterialesB> detalle { get; set; }
    }
}
