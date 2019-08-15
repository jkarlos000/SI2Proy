using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class NoConformidad
    {
        public NoConformidad()
        {
            DetalleControlCalidad = new HashSet<DetalleControlCalidad>();
        }

        [Column("cod_no_conformidad")]
        public int CodNoConformidad { get; set; }
        [Column("descripcion_no_conformidad")]
        public string DescripcionNoConformidad { get; set; }
        [Column("proceso_fk")]
        public int? ProcesoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("ProcesoFk")]
        [InverseProperty("NoConformidad")]
        public virtual Proceso ProcesoFkNavigation { get; set; }
        [InverseProperty("NoConformidadFkNavigation")]
        public virtual ICollection<DetalleControlCalidad> DetalleControlCalidad { get; set; }
    }
}
