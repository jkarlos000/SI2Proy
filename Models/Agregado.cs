using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Agregado
    {
        public Agregado()
        {
            Inventario = new HashSet<Inventario>();
        }

        [Display(Name = "Codigo Materia Prima")]
        [Column("cod_materia_prima")]
        public int CodMateriaPrima { get; set; }

        [Display(Name ="Nombre")]
        [Column("nombre_materia_prima")]
        [StringLength(50)]
        public string NombreMateriaPrima { get; set; }

        [ForeignKey("CodMateriaPrima")]
        [InverseProperty("Agregado")]
        public virtual MateriaPrima CodMateriaPrimaNavigation { get; set; }

        [InverseProperty("AgregadoFkNavigation")]
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
