using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Persona
    {
        [Column("numero_cliente")]
        public int NumeroCliente { get; set; }

        [Display(Name ="Cedula")]
        [Column("numero_cedula")]
        [StringLength(15)]
        public string NumeroCedula { get; set; }

        [Display(Name ="Nombres")]
        [Column("nombre_cliente")]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        [ForeignKey("NumeroCliente")]
        [InverseProperty("Persona")]
        public virtual Cliente NumeroClienteNavigation { get; set; }
    }
}
