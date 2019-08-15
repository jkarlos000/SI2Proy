using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            DetalleOrdenProduccion = new HashSet<DetalleOrdenProduccion>();
            NoConformidad = new HashSet<NoConformidad>();
            TiempoProduccion = new HashSet<TiempoProduccion>();
        }

        [Column("cod_proceso")]
        public int CodProceso { get; set; }
        [Column("nombre_proceso")]
        [StringLength(50)]
        public string NombreProceso { get; set; }
        [Column("descripcion_proceso")]
        public string DescripcionProceso { get; set; }
        [Column("linea_produccion_fk")]
        public int? LineaProduccionFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("LineaProduccionFk")]
        [InverseProperty("Proceso")]
        public virtual LineaProduccion LineaProduccionFkNavigation { get; set; }
        [InverseProperty("ProcesoFkNavigation")]
        public virtual ICollection<DetalleOrdenProduccion> DetalleOrdenProduccion { get; set; }
        [InverseProperty("ProcesoFkNavigation")]
        public virtual ICollection<NoConformidad> NoConformidad { get; set; }
        [InverseProperty("ProcesoFkNavigation")]
        public virtual ICollection<TiempoProduccion> TiempoProduccion { get; set; }
    }
}
