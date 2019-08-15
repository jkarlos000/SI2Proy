using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Empresa
    {
        [Column("numero_cliente")]
        public int NumeroCliente { get; set; }
        [Column("ruc")]
        [StringLength(15)]
        public string Ruc { get; set; }
        [Column("nombre_empresa")]
        [StringLength(50)]
        public string NombreEmpresa { get; set; }
        [Column("representante")]
        [StringLength(100)]
        public string Representante { get; set; }

        [ForeignKey("NumeroCliente")]
        [InverseProperty("Empresa")]
        public virtual Cliente NumeroClienteNavigation { get; set; }
    }
}
