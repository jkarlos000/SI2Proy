using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Display(Name ="Vendedor Numero")]
        [Column("numero_vendedor")]
        public int NumeroVendedor { get; set; }

        [Display(Name = "Cedula")]
        [Column("numero_cedula")]
        [StringLength(10)]
        public string NumeroCedula { get; set; }

        [Display(Name = "RUC")]
        [Column("numero_ruc")]
        [StringLength(15)]
        public string NumeroRuc { get; set; }

        [Display(Name = "Nombres / Apellidos")]
        [Column("nombre_vendedor")]
        [StringLength(100)]
        public string NombreVendedor { get; set; }

        [Display(Name = "Direccion")]
        [Column("direccion")]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Display(Name = "Telefono Fijo")]
        [Column("telefono")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Display(Name = "Telefono Celular")]
        [Column("telefono_celular")]
        [StringLength(15)]
        public string TelefonoCelular { get; set; }

        [Display(Name = "Record de Ventas")]
        [Column("record_ventas")]
        public int? RecordVentas { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("VendedorFkNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
