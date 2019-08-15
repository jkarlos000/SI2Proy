using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DetallePedido
    {
        public DetallePedido()
        {
            PlanMaestroProduccion = new HashSet<PlanMaestroProduccion>();
        }

        [Column("cod_detalle")]
        public int CodDetalle { get; set; }
        [Column("cantidad_detalle")]
        public int? CantidadDetalle { get; set; }
        [Column("precio_total_detalle")]
        public int? PrecioTotalDetalle { get; set; }
        [Column("detalle_pedido_finalizado")]
        public bool? DetallePedidoFinalizado { get; set; }
        [Column("pedido_fk")]
        public int? PedidoFk { get; set; }
        [Column("modelo_producto_fk")]
        public int? ModeloProductoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("ModeloProductoFk")]
        [InverseProperty("DetallePedido")]
        public virtual ModeloProducto ModeloProductoFkNavigation { get; set; }
        [ForeignKey("PedidoFk")]
        [InverseProperty("DetallePedido")]
        public virtual Pedido PedidoFkNavigation { get; set; }
        [InverseProperty("DetallePedidoFkNavigation")]
        public virtual ICollection<PlanMaestroProduccion> PlanMaestroProduccion { get; set; }
    }
}
