using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class LineaProduccion
    {
        public LineaProduccion()
        {
            DesgloseProyeccionLineaProduccion = new HashSet<DesgloseProyeccionLineaProduccion>();
            ModeloProducto = new HashSet<ModeloProducto>();
            PlanMaestroProduccion = new HashSet<PlanMaestroProduccion>();
            Proceso = new HashSet<Proceso>();
        }

        [Display(Name ="Linea de Produccion Numero")]
        [Column("numero_linea_produccion")]
        public int NumeroLineaProduccion { get; set; }

        [Display(Name = "Linea de Produccion")]
        [Column("nombre_linea_produccion")]
        [StringLength(50)]
        public string NombreLineaProduccion { get; set; }

        [Display(Name = "Descripcion")]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Creacion")]
        [Column("fecha_creacion", TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("LineaProduccionFkNavigation")]
        public virtual ICollection<DesgloseProyeccionLineaProduccion> DesgloseProyeccionLineaProduccion { get; set; }
        [InverseProperty("LineaProduccionFkNavigation")]
        public virtual ICollection<ModeloProducto> ModeloProducto { get; set; }
        [InverseProperty("LineaProduccionFkNavigation")]
        public virtual ICollection<PlanMaestroProduccion> PlanMaestroProduccion { get; set; }
        [InverseProperty("LineaProduccionFkNavigation")]
        public virtual ICollection<Proceso> Proceso { get; set; }
    }
}
