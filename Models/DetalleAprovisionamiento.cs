using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class DetalleAprovisionamiento
    {


        [Column("cod_detalle")]
        public int CodDetalle { get; set; }

        [Display(Name = "Cantidad")]
        [Column("cantidad")]
        public int? Cantidad { get; set; }

        [Display(Name ="Ingresado")]
        [Column("ingresado")]
        public bool? Ingresado { get; set; }

        [Display(Name ="Observacion")]
        [Column("observacion")]
        public string Observacion { get; set; }

        [Column("orden_aprovisionamiento_fk")]
        public int? OrdenAprovisionamientoFk { get; set; }

        [Column("inventario_fk")]
        public int? InventarioFk { get; set; }

        [ForeignKey("InventarioFk")]
        [InverseProperty("DetalleAprovisionamiento")]
        public virtual Inventario InventarioFkNavigation { get; set; }

        [ForeignKey("OrdenAprovisionamientoFk")]
        [InverseProperty("DetalleAprovisionamiento")]
        public virtual OrdenAprovisionamiento OrdenAprovisionamientoFkNavigation { get; set; }
    }
}
