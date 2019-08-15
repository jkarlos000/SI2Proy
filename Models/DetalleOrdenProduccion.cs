using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DetalleOrdenProduccion
    {
        public DetalleOrdenProduccion()
        {
            ControlCalidadNavigation = new HashSet<ControlCalidad>();
        }

        [Column("cod_detalle_orden")]
        public int CodDetalleOrden { get; set; }
        [Column("fecha_inicio", TypeName = "datetime")]
        public DateTime? FechaInicio { get; set; }
        [Column("hora_inicio", TypeName = "datetime")]
        public DateTime? HoraInicio { get; set; }
        [Column("fecha_fin", TypeName = "datetime")]
        public DateTime? FechaFin { get; set; }
        [Column("hora_fin", TypeName = "datetime")]
        public DateTime? HoraFin { get; set; }
        [Column("observacion")]
        public string Observacion { get; set; }
        [Column("control_calidad")]
        public bool? ControlCalidad { get; set; }
        [Column("orden_produccion_fk")]
        public int? OrdenProduccionFk { get; set; }
        [Column("proceso_fk")]
        public int? ProcesoFk { get; set; }

        [ForeignKey("OrdenProduccionFk")]
        [InverseProperty("DetalleOrdenProduccion")]
        public virtual OrdenProduccion OrdenProduccionFkNavigation { get; set; }
        [ForeignKey("ProcesoFk")]
        [InverseProperty("DetalleOrdenProduccion")]
        public virtual Proceso ProcesoFkNavigation { get; set; }
        [InverseProperty("DetalleOrdenProduccionFkNavigation")]
        public virtual ICollection<ControlCalidad> ControlCalidadNavigation { get; set; }
    }
}
