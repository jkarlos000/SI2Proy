using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class MovimientoInventario
    {

        [Display(Name ="Codigo Movimiento Inventario")]
        [Column("cod_movimiento_inventario")]
        public int CodMovimientoInventario { get; set; }

        [Display(Name ="Tipo Movimiento")]
        [Column("tipo_movimiento")]
        [StringLength(1)]
        public string TipoMovimiento { get; set; }
        [Column("fecha_movimiento", TypeName = "datetime")]
        public DateTime? FechaMovimiento { get; set; }
        [Column("factura")]
        public string Factura { get; set; }
        [Column("precio_unitario")]
        public int? PrecioUnitario { get; set; }
        [Column("cantidad")]
        public int? Cantidad { get; set; }
        [Column("observacion")]
        public string Observacion { get; set; }
        [Column("inventario_fk")]
        public int? InventarioFk { get; set; }
        [Column("proveedor_fk")]
        public int? ProveedorFk { get; set; }
        [Column("orden_aprovisionamiento_fk")]
        public int? OrdenAprovisionamientoFk { get; set; }
        [Column("digitador")]
        public string Digitador { get; set; }
        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("InventarioFk")]
        [InverseProperty("MovimientoInventario")]
        public virtual Inventario InventarioFkNavigation { get; set; }
        [ForeignKey("OrdenAprovisionamientoFk")]
        [InverseProperty("MovimientoInventario")]
        public virtual OrdenAprovisionamiento OrdenAprovisionamientoFkNavigation { get; set; }
        [ForeignKey("ProveedorFk")]
        [InverseProperty("MovimientoInventario")]
        public virtual Proveedor ProveedorFkNavigation { get; set; }
    }
}
