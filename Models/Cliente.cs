using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Display(Name = "Cliente Numero")]
        [Column("numero_cliente")]
        public int NumeroCliente { get; set; }
        [Column("direccion")]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Display(Name ="Fecha de Ingreso")]
        [Column("fecha_ingreso", TypeName = "datetime")]
        public DateTime? FechaIngreso { get; set; }

        [Display(Name ="Telefono Fijo")]
        [Column("telefono")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Display(Name ="Telefono Celular")]
        [Column("telefono_celular")]
        [StringLength(15)]
        public string TelefonoCelular { get; set; }

        [Display(Name ="Prioridad Cliente")]
        [Column("prioridad_cliente")]
        [Range(1,3)]
        public int? PrioridadCliente { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [InverseProperty("NumeroClienteNavigation")]
        public virtual Empresa Empresa { get; set; }
        [InverseProperty("NumeroClienteNavigation")]
        public virtual Persona Persona { get; set; }
        [InverseProperty("ClienteFkNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
