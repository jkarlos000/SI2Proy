using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        [Display(Name ="Orden Compra (Sistema)")]
        [Column("numero_orden_compra")]
        public int NumeroOrdenCompra { get; set; }

        [Display(Name = "Nota de Pedido Nro.")]
        [Column("numero_nota_pedido")]
        [StringLength(15)]
        public string NumeroNotaPedido { get; set; }

        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [Column("precio_total")]
        public int? PrecioTotal { get; set; }

        [Display(Name = "Fecha Entrega")]
        [DataType(DataType.Date)]
        [Column("fecha_entrega", TypeName = "datetime")]
        public DateTime? FechaEntrega { get; set; }

        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Column("fecha_real_entrega_pedido", TypeName = "datetime")]
        public DateTime? FechaRealEntregaPedido { get; set; }

        [Display(Name = "Pedido Finalizado")]
        [Column("pedido_finalizado")]
        public bool? PedidoFinalizado { get; set; }

        [Column("cliente_fk")]
        public int? ClienteFk { get; set; }//
        [Column("vendedor_fk")]
        public int? VendedorFk { get; set; }//

        [Column("digitador")]
        public string Digitador { get; set; }

        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("ClienteFk")]
        [InverseProperty("Pedido")]
        public virtual Cliente ClienteFkNavigation { get; set; }
        [ForeignKey("VendedorFk")]
        [InverseProperty("Pedido")]
        public virtual Vendedor VendedorFkNavigation { get; set; }
        [InverseProperty("PedidoFkNavigation")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
