using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class PlanificacionProyeccionMensual
    {
        public PlanificacionProyeccionMensual()
        {
            DesgloseProyeccionProduccionMensual = new HashSet<DesgloseProyeccionProduccionMensual>();
        }

        [Column("anio")]
        public int Anio { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("PlanificacionProyeccionMensualFkNavigation")]
        public virtual ICollection<DesgloseProyeccionProduccionMensual> DesgloseProyeccionProduccionMensual { get; set; }
    }
}
