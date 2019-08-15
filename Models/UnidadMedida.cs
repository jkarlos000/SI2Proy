using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            MateriaPrima = new HashSet<MateriaPrima>();
        }

        [Display(Name ="Codigo")]
        [Column("cod_unidad_medida")]
        public int CodUnidadMedida { get; set; }

        [Display(Name = "Unidad de Medida")]
        [Column("nombre_unidad_medida")]
        [StringLength(50)]
        public string NombreUnidadMedida { get; set; }

        [Display(Name = "Abreviatura")]
        [Column("abreviatura")]
        [StringLength(10)]
        public string Abreviatura { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }

        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("UnidadMedidaFkNavigation")]
        public virtual ICollection<MateriaPrima> MateriaPrima { get; set; }
    }
}
