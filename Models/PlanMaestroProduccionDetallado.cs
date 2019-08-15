using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class PlanMaestroProduccionDetallado
    {
        public PlanMaestroProduccionDetallado()
        {
            OrdenProduccion = new HashSet<OrdenProduccion>();
        }

        [Column("numero_ingreso")]
        public int NumeroIngreso { get; set; }
        [Column("dia", TypeName = "datetime")]
        public DateTime? Dia { get; set; }
        [Column("fecha_ingreso_hoja_ruta", TypeName = "datetime")]
        public DateTime? FechaIngresoHojaRuta { get; set; }
        [Column("observaciones")]
        public string Observaciones { get; set; }
        [Column("plan_maestro_produccion_fk")]
        public int? PlanMaestroProduccionFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("PlanMaestroProduccionFk")]
        [InverseProperty("PlanMaestroProduccionDetallado")]
        public virtual PlanMaestroProduccion PlanMaestroProduccionFkNavigation { get; set; }
        [InverseProperty("PlanMaestroProduccionDetalladoFkNavigation")]
        public virtual ICollection<OrdenProduccion> OrdenProduccion { get; set; }
    }
}
