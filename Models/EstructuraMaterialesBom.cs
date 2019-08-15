using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class EstructuraMaterialesBom
    {
        [Column("cod_bom")]
        public int CodBom { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("cantidad_por_producto")]
        public int? CantidadPorProducto { get; set; }
        [Column("fecha_vigencia", TypeName = "datetime")]
        public DateTime? FechaVigencia { get; set; }
        [Column("obligatorio")]
        public bool? Obligatorio { get; set; }
        [Column("materia_prima_fk")]
        public int? MateriaPrimaFk { get; set; }
        [Column("modelo_producto_fk")]
        public int? ModeloProductoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("MateriaPrimaFk")]
        [InverseProperty("EstructuraMaterialesBom")]
        public virtual MateriaPrima MateriaPrimaFkNavigation { get; set; }

        [ForeignKey("ModeloProductoFk")]
        [InverseProperty("EstructuraMaterialesBom")]
        public virtual ModeloProducto ModeloProductoFkNavigation { get; set; }
    }
}
