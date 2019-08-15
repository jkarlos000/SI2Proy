using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class MateriaPrima
    {
        public MateriaPrima()
        {
            EstructuraMaterialesBom = new HashSet<EstructuraMaterialesBom>();
        }

        [Display(Name = "Codigo")]
        [Column("cod_materia_prima")]
        public int CodMateriaPrima { get; set; }

        [Display(Name = "Descripcion")]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Display(Name ="Fecha de Creacion")]
        [Column("fecha_creacion", TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }

        [Display(Name ="Estado")]
        [Column("activo")]
        public bool? Activo { get; set; }

        [Column("tipo")]
        [StringLength(1)]
        public string Tipo { get; set; }  ///

        [Column("insumo_fk")]
        public int? InsumoFk { get; set; } ///

        [Column("unidad_medida_fk")]
        public int? UnidadMedidaFk { get; set; } ///

        [Column("digitador")]
        public string Digitador { get; set; }

        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("InsumoFk")]
        [InverseProperty("MateriaPrima")]
        public virtual Insumo InsumoFkNavigation { get; set; }

        [ForeignKey("UnidadMedidaFk")]
        [InverseProperty("MateriaPrima")]
        public virtual UnidadMedida UnidadMedidaFkNavigation { get; set; }

        [InverseProperty("CodMateriaPrimaNavigation")]
        public virtual Agregado Agregado { get; set; }

        [InverseProperty("MateriaPrimaFkNavigation")]
        public virtual ICollection<EstructuraMaterialesBom> EstructuraMaterialesBom { get; set; }
    }
}
