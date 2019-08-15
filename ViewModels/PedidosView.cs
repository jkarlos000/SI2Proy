using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SI2Proy.Models;

namespace SI2Proy.ViewModels
{
    public class PedidosView
    {
        public List<DetallePedidoView> detalle { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int NumeroCliente { get; set; }
        public int NumeroVendedor { get; set; }
        public string Observaciones { get; set; }

    }
}
