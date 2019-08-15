using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            MateriaPrima = new HashSet<MateriaPrima>();
        }

        [Display(Name ="Codigo Insumo")]
        [Column("cod_insumo")]
        public int CodInsumo { get; set; }

        [Display(Name = "Insumo")]
        [Column("nombre_insumo")]
        [StringLength(50)]
        public string NombreInsumo { get; set; }

        [Display(Name = "Fecha Creacion")]
        [Column("fecha_creacion", TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("InsumoFkNavigation")]
        public virtual ICollection<MateriaPrima> MateriaPrima { get; set; }
    }
}
