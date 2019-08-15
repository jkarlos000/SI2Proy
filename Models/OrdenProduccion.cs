using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class OrdenProduccion
    {
        public OrdenProduccion()
        {
            DetalleOrdenProduccion = new HashSet<DetalleOrdenProduccion>();
        }

        [Column("numero_tarjeta_fabricacion")]
        public int NumeroTarjetaFabricacion { get; set; }
        [Column("cerco")]
        public bool? Cerco { get; set; }
        [Column("corrida")]
        [StringLength(10)]
        public string Corrida { get; set; }
        [Column("fecha_creacion", TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [Column("hora_creacion")]
        public TimeSpan? HoraCreacion { get; set; }
        [Column("plan_maestro_produccion_detallado_fk")]
        public int? PlanMaestroProduccionDetalladoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("PlanMaestroProduccionDetalladoFk")]
        [InverseProperty("OrdenProduccion")]
        public virtual PlanMaestroProduccionDetallado PlanMaestroProduccionDetalladoFkNavigation { get; set; }
        [InverseProperty("OrdenProduccionFkNavigation")]
        public virtual ICollection<DetalleOrdenProduccion> DetalleOrdenProduccion { get; set; }
    }
}
