using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DesgloseProyeccionLineaProduccion
    {
        [Column("cod_desglose_linea_produccion")]
        public int CodDesgloseLineaProduccion { get; set; }
        [Column("porcentaje_produccion")]
        public int? PorcentajeProduccion { get; set; }
        [Column("total_cant_producto_producir_mes_linea_produccion")]
        public int? TotalCantProductoProducirMesLineaProduccion { get; set; }
        [Column("desglose_proyeccion_produccion_mensual_fk")]
        public int? DesgloseProyeccionProduccionMensualFk { get; set; }
        [Column("linea_produccion_fk")]
        public int? LineaProduccionFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("DesgloseProyeccionProduccionMensualFk")]
        [InverseProperty("DesgloseProyeccionLineaProduccion")]
        public virtual DesgloseProyeccionProduccionMensual DesgloseProyeccionProduccionMensualFkNavigation { get; set; }
        [ForeignKey("LineaProduccionFk")]
        [InverseProperty("DesgloseProyeccionLineaProduccion")]
        public virtual LineaProduccion LineaProduccionFkNavigation { get; set; }
    }
}
