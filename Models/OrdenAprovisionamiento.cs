using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class OrdenAprovisionamiento
    {
        public OrdenAprovisionamiento()
        {
            DetalleAprovisionamiento = new HashSet<DetalleAprovisionamiento>();
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        [Display(Name ="Nro. Orden")]
        [Column("numero_orden_aprovisionamiento")]
        public int NumeroOrdenAprovisionamiento { get; set; }

        [Display(Name = "Fecha Emision")]
        [Column("fecha_emision", TypeName = "datetime")]
        public DateTime? FechaEmision { get; set; }

        [Column("observacion")]
        public string Observacion { get; set; }


        [Display(Name = "Fecha Estimada Entrega")]
        [DataType(DataType.Date)]
        [Column("fecha_estimada_entrega", TypeName = "datetime")]
        public DateTime? FechaEstimadaEntrega { get; set; }

        [Display(Name = "Fecha Entrega")]
        [DataType(DataType.Date)]
        [Column("fecha_entrega", TypeName = "datetime")]
        public DateTime? FechaEntrega { get; set; }

        [Display(Name = "Aprobado")]
        [Column("aprobado")]
        public bool? Aprobado { get; set; }


        [Column("aprobado_por")]
        public string AprobadoPor { get; set; }

        [Display(Name = "Estado de la Entrega")]
        [Column("estado_entregado")]
        public bool? EstadoEntregado { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }

        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("OrdenAprovisionamientoFkNavigation")]
        public virtual ICollection<DetalleAprovisionamiento> DetalleAprovisionamiento { get; set; }
        [InverseProperty("OrdenAprovisionamientoFkNavigation")]
        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
