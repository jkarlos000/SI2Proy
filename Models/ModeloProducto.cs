using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class ModeloProducto
    {
        public ModeloProducto()
        {
            DetallePedido = new HashSet<DetallePedido>();
            EstructuraMaterialesBom = new HashSet<EstructuraMaterialesBom>();
        }

        [Display(Name ="Codigo (Sistema)")]
        [Column("cod_estructura_materia")]
        public int CodEstructuraMateria { get; set; }

        [Display(Name = "Codigo (Producto)")]
        [Column("codigo_producto")]
        [StringLength(20)]
        public string CodigoProducto { get; set; }  //

        [Display(Name = "Nombre Modelo")]
        [Column("nombre_modelo")]
        [StringLength(50)]
        public string NombreModelo { get; set; }

        [Column("tamano_estandar")]
        [StringLength(4)]
        public string TamanoEstandar { get; set; }

        [Display(Name = "Precio Unitario")]
        [Column("precio_unitario")]
        public int? PrecioUnitario { get; set; }

        [Display(Name ="Observacion")]
        [Column("observaciones")]
        public string Observaciones { get; set; }

        [Display(Name = "Estado")]
        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("linea_produccion_fk")]
        public int? LineaProduccionFk { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }

        [DataType(DataType.Date)]
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("LineaProduccionFk")]
        [InverseProperty("ModeloProducto")]
        public virtual LineaProduccion LineaProduccionFkNavigation { get; set; }
        [InverseProperty("ModeloProductoFkNavigation")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
        [InverseProperty("ModeloProductoFkNavigation")]
        public virtual ICollection<EstructuraMaterialesBom> EstructuraMaterialesBom { get; set; }
    }
}
