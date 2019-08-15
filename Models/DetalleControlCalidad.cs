using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DetalleControlCalidad
    {
        [Column("cod_detalle_control_calidad")]
        public int CodDetalleControlCalidad { get; set; }
        [Column("total_no_conformidad")]
        public int? TotalNoConformidad { get; set; }
        [Column("control_calidad_fk")]
        public int? ControlCalidadFk { get; set; }
        [Column("no_conformidad_fk")]
        public int? NoConformidadFk { get; set; }

        [ForeignKey("ControlCalidadFk")]
        [InverseProperty("DetalleControlCalidad")]
        public virtual ControlCalidad ControlCalidadFkNavigation { get; set; }
        [ForeignKey("NoConformidadFk")]
        [InverseProperty("DetalleControlCalidad")]
        public virtual NoConformidad NoConformidadFkNavigation { get; set; }
    }
}
