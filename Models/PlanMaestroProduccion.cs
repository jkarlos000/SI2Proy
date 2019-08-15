using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class PlanMaestroProduccion
    {
        public PlanMaestroProduccion()
        {
            PlanMaestroProduccionDetallado = new HashSet<PlanMaestroProduccionDetallado>();
        }

        [Column("numero_ingreso")]
        public int NumeroIngreso { get; set; }
        [Column("mes_anio", TypeName = "datetime")]
        public DateTime? MesAnio { get; set; }
        [Column("fecha_ingreso", TypeName = "datetime")]
        public DateTime? FechaIngreso { get; set; }
        [Column("fecha_prevista_ingreso_prod", TypeName = "datetime")]
        public DateTime? FechaPrevistaIngresoProd { get; set; }
        [Column("numero_lote")]
        public int? NumeroLote { get; set; }
        [Column("observaciones")]
        public string Observaciones { get; set; }
        [Column("linea_produccion_fk")]
        public int? LineaProduccionFk { get; set; }
        [Column("detalle_pedido_fk")]
        public int? DetallePedidoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("DetallePedidoFk")]
        [InverseProperty("PlanMaestroProduccion")]
        public virtual DetallePedido DetallePedidoFkNavigation { get; set; }
        [ForeignKey("LineaProduccionFk")]
        [InverseProperty("PlanMaestroProduccion")]
        public virtual LineaProduccion LineaProduccionFkNavigation { get; set; }
        [InverseProperty("PlanMaestroProduccionFkNavigation")]
        public virtual ICollection<PlanMaestroProduccionDetallado> PlanMaestroProduccionDetallado { get; set; }
    }
}
