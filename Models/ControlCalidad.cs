using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class ControlCalidad
    {
        public ControlCalidad()
        {
            DetalleControlCalidad = new HashSet<DetalleControlCalidad>();
        }

        [Column("numero_control_calidad")]
        public int NumeroControlCalidad { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [Column("hora", TypeName = "datetime")]
        public DateTime? Hora { get; set; }
        [Column("tamano_lote")]
        public int? TamanoLote { get; set; }
        [Column("tamano_muestra")]
        public int? TamanoMuestra { get; set; }
        [Column("total_defectos")]
        public int? TotalDefectos { get; set; }
        [Column("detalle_orden_produccion_fk")]
        public int? DetalleOrdenProduccionFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("DetalleOrdenProduccionFk")]
        [InverseProperty("ControlCalidadNavigation")]
        public virtual DetalleOrdenProduccion DetalleOrdenProduccionFkNavigation { get; set; }
        [InverseProperty("ControlCalidadFkNavigation")]
        public virtual ICollection<DetalleControlCalidad> DetalleControlCalidad { get; set; }
    }
}
