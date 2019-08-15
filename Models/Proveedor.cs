using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        [Display(Name ="Proveedor Numero")]
        [Column("numero_proveedor")]
        public int NumeroProveedor { get; set; }

        [Display(Name ="Cedula o RUC")]
        [Column("numero_cedula_ruc")]
        [StringLength(15)]
        public string NumeroCedulaRuc { get; set; }

        [Display(Name ="Nombre Proveedor")]
        [Column("nombre_proveedor")]
        [StringLength(100)]
        public string NombreProveedor { get; set; }

        [Display(Name ="Direccion")]
        [Column("direccion")]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Display(Name ="Telefono Fijo")]
        [Column("telefono")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Display(Name = "Telefono Celular")]
        [Column("telefono_celular")]
        [StringLength(15)]
        public string TelefonoCelular { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("ProveedorFkNavigation")]
        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
