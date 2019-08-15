using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SI2Proy.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            DetalleAprovisionamiento = new HashSet<DetalleAprovisionamiento>();
            MovimientoInventario = new HashSet<MovimientoInventario>();
        }

        [Display(Name = "Codigo")]
        [Column("cod_inventario")]
        public int CodInventario { get; set; }

        [Display(Name ="Cantidad (Stock)")] //No estoy seguro de que este seea el Cantidad(Stock) revisar luego
        [Column("total")]
        public int? Total { get; set; }                  ///

        [Display(Name ="Saldo (PRO)")]
        [Column("saldo_pro")]
        public int? SaldoPro { get; set; }               

        [Display(Name ="Pedir(Q)")]
        [Column("pedir_q")]
        public int? PedirQ { get; set; }

        [Column("stock_maximo")]
        public int? StockMaximo { get; set; }          /// 

        [Column("stock_comprometido")]
        public int? StockComprometido { get; set; }         ///

        [Column("fecha_stock_comprometido", TypeName = "datetime")]
        public DateTime? FechaStockComprometido { get; set; }      ///

        [Column("agregado_fk")]
        public int? AgregadoFk { get; set; }

        [Column("digitador")]
        public string Digitador { get; set; }

        [Column("fecha_digitador", TypeName = "datetime")]
        public DateTime? FechaDigitador { get; set; }

        [ForeignKey("AgregadoFk")]
        [InverseProperty("Inventario")]
        public virtual Agregado AgregadoFkNavigation { get; set; }

        [InverseProperty("InventarioFkNavigation")]
        public virtual ICollection<DetalleAprovisionamiento> DetalleAprovisionamiento { get; set; }

        [InverseProperty("InventarioFkNavigation")]
        public virtual ICollection<MovimientoInventario> MovimientoInventario { get; set; }
    }
}
