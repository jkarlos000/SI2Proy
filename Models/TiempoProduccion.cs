using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class TiempoProduccion
    {
        [Column("numero_ingreso_t")]
        public int NumeroIngresoT { get; set; }
        [Column("numero_obreros")]
        public int? NumeroObreros { get; set; }
        [Column("fecha_jornada", TypeName = "datetime")]
        public DateTime? FechaJornada { get; set; }
        [Column("hora_inicio_jornada", TypeName = "datetime")]
        public DateTime? HoraInicioJornada { get; set; }
        [Column("hora_fin_jornada", TypeName = "datetime")]
        public DateTime? HoraFinJornada { get; set; }
        [Column("tiempo_total_receso", TypeName = "datetime")]
        public DateTime? TiempoTotalReceso { get; set; }
        [Column("tiempo_laborado", TypeName = "datetime")]
        public DateTime? TiempoLaborado { get; set; }
        [Column("observacion")]
        public string Observacion { get; set; }
        [Column("proceso_fk")]
        public int? ProcesoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("ProcesoFk")]
        [InverseProperty("TiempoProduccion")]
        public virtual Proceso ProcesoFkNavigation { get; set; }
    }
}
