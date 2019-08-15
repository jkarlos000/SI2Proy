using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DesgloseProyeccionProduccionMensual
    {
        public DesgloseProyeccionProduccionMensual()
        {
            DesgloseProyeccionLineaProduccion = new HashSet<DesgloseProyeccionLineaProduccion>();
        }

        [Column("numero_mes_ano")]
        public int NumeroMesAno { get; set; }
        [Column("numero_productos_proyectado_fabricar")]
        public int? NumeroProductosProyectadoFabricar { get; set; }
        [Column("total_dias_laborales_mes")]
        public int? TotalDiasLaboralesMes { get; set; }
        [Column("total_producto_producir_mes")]
        public int? TotalProductoProducirMes { get; set; }
        [Column("observacion")]
        public string Observacion { get; set; }
        [Column("planificacion_proyeccion_mensual_fk")]
        public int? PlanificacionProyeccionMensualFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("PlanificacionProyeccionMensualFk")]
        [InverseProperty("DesgloseProyeccionProduccionMensual")]
        public virtual PlanificacionProyeccionMensual PlanificacionProyeccionMensualFkNavigation { get; set; }
        [InverseProperty("DesgloseProyeccionProduccionMensualFkNavigation")]
        public virtual ICollection<DesgloseProyeccionLineaProduccion> DesgloseProyeccionLineaProduccion { get; set; }
    }
}
