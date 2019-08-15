using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SI2Proy.Models
{
    public partial class ProduccionContext : DbContext
    {
        public ProduccionContext()
        {
        }

        public ProduccionContext(DbContextOptions<ProduccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agregado> Agregado { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ControlCalidad> ControlCalidad { get; set; }
        public virtual DbSet<DesgloseProyeccionLineaProduccion> DesgloseProyeccionLineaProduccion { get; set; }
        public virtual DbSet<DesgloseProyeccionProduccionMensual> DesgloseProyeccionProduccionMensual { get; set; }
        public virtual DbSet<DetalleAprovisionamiento> DetalleAprovisionamiento { get; set; }
        public virtual DbSet<DetalleControlCalidad> DetalleControlCalidad { get; set; }
        public virtual DbSet<DetalleOrdenProduccion> DetalleOrdenProduccion { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<EstructuraMaterialesBom> EstructuraMaterialesBom { get; set; }
        public virtual DbSet<Insumo> Insumo { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<LineaProduccion> LineaProduccion { get; set; }
        public virtual DbSet<MateriaPrima> MateriaPrima { get; set; }
        public virtual DbSet<ModeloProducto> ModeloProducto { get; set; }
        public virtual DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        public virtual DbSet<NoConformidad> NoConformidad { get; set; }
        public virtual DbSet<OrdenAprovisionamiento> OrdenAprovisionamiento { get; set; }
        public virtual DbSet<OrdenProduccion> OrdenProduccion { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PlanMaestroProduccion> PlanMaestroProduccion { get; set; }
        public virtual DbSet<PlanMaestroProduccionDetallado> PlanMaestroProduccionDetallado { get; set; }
        public virtual DbSet<PlanificacionProyeccionMensual> PlanificacionProyeccionMensual { get; set; }
        public virtual DbSet<Proceso> Proceso { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TiempoProduccion> TiempoProduccion { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            /*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.*/
                optionsBuilder.UseSqlServer("Server=tcp:mssql.si2proy.ml,1433;Initial Catalog=Produccion;MultipleActiveResultSets=true;User ID=sa;Password=Cambiamejk1!.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Agregado>(entity =>
            {
                entity.HasKey(e => e.CodMateriaPrima)
                    .HasName("PK__Agregado__8262F779A7566A38");

                entity.Property(e => e.CodMateriaPrima).ValueGeneratedNever();

                entity.Property(e => e.NombreMateriaPrima).IsUnicode(false);

                entity.HasOne(d => d.CodMateriaPrimaNavigation)
                    .WithOne(p => p.Agregado)
                    .HasForeignKey<Agregado>(d => d.CodMateriaPrima)
                    .HasConstraintName("FK__Agregado__cod_ma__0C85DE4D");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.NumeroCliente)
                    .HasName("PK__Cliente__DA28746217A07AC9");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TelefonoCelular).IsUnicode(false);
            });

            modelBuilder.Entity<ControlCalidad>(entity =>
            {
                entity.HasKey(e => e.NumeroControlCalidad)
                    .HasName("PK__ControlC__CBF8F5AEFFE67087");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.DetalleOrdenProduccionFkNavigation)
                    .WithMany(p => p.ControlCalidadNavigation)
                    .HasForeignKey(d => d.DetalleOrdenProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ControlCa__detal__787EE5A0");
            });

            modelBuilder.Entity<DesgloseProyeccionLineaProduccion>(entity =>
            {
                entity.HasKey(e => e.CodDesgloseLineaProduccion)
                    .HasName("PK__Desglose__4623E72D7CBF22E7");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.DesgloseProyeccionProduccionMensualFkNavigation)
                    .WithMany(p => p.DesgloseProyeccionLineaProduccion)
                    .HasForeignKey(d => d.DesgloseProyeccionProduccionMensualFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DesgloseP__desgl__6477ECF3");

                entity.HasOne(d => d.LineaProduccionFkNavigation)
                    .WithMany(p => p.DesgloseProyeccionLineaProduccion)
                    .HasForeignKey(d => d.LineaProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DesgloseP__linea__656C112C");
            });

            modelBuilder.Entity<DesgloseProyeccionProduccionMensual>(entity =>
            {
                entity.HasKey(e => e.NumeroMesAno)
                    .HasName("PK__Desglose__4D6FBD777FDF122F");

                entity.Property(e => e.NumeroMesAno).ValueGeneratedNever();

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.HasOne(d => d.PlanificacionProyeccionMensualFkNavigation)
                    .WithMany(p => p.DesgloseProyeccionProduccionMensual)
                    .HasForeignKey(d => d.PlanificacionProyeccionMensualFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DesgloseP__plani__619B8048");
            });

            modelBuilder.Entity<DetalleAprovisionamiento>(entity =>
            {
                entity.HasKey(e => e.CodDetalle)
                    .HasName("PK__DetalleA__03E666AE79BED8D2");

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.HasOne(d => d.InventarioFkNavigation)
                    .WithMany(p => p.DetalleAprovisionamiento)
                    .HasForeignKey(d => d.InventarioFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetalleAp__inven__1AD3FDA4");

                entity.HasOne(d => d.OrdenAprovisionamientoFkNavigation)
                    .WithMany(p => p.DetalleAprovisionamiento)
                    .HasForeignKey(d => d.OrdenAprovisionamientoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetalleAp__orden__19DFD96B");
            });

            modelBuilder.Entity<DetalleControlCalidad>(entity =>
            {
                entity.HasKey(e => e.CodDetalleControlCalidad)
                    .HasName("PK__DetalleC__E6A8A05BAE951F38");

                entity.HasOne(d => d.ControlCalidadFkNavigation)
                    .WithMany(p => p.DetalleControlCalidad)
                    .HasForeignKey(d => d.ControlCalidadFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetalleCo__contr__7E37BEF6");

                entity.HasOne(d => d.NoConformidadFkNavigation)
                    .WithMany(p => p.DetalleControlCalidad)
                    .HasForeignKey(d => d.NoConformidadFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetalleCo__no_co__7F2BE32F");
            });

            modelBuilder.Entity<DetalleOrdenProduccion>(entity =>
            {
                entity.HasKey(e => e.CodDetalleOrden)
                    .HasName("PK__DetalleO__6EA4E1E7508AB731");

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.HasOne(d => d.OrdenProduccionFkNavigation)
                    .WithMany(p => p.DetalleOrdenProduccion)
                    .HasForeignKey(d => d.OrdenProduccionFk)
                    .HasConstraintName("FK__DetalleOr__orden__74AE54BC");

                entity.HasOne(d => d.ProcesoFkNavigation)
                    .WithMany(p => p.DetalleOrdenProduccion)
                    .HasForeignKey(d => d.ProcesoFk)
                    .HasConstraintName("FK__DetalleOr__proce__75A278F5");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.CodDetalle)
                    .HasName("PK__DetalleP__03E666AEB8CCCA85");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.ModeloProductoFkNavigation)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.ModeloProductoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetallePe__model__5CD6CB2B");

                entity.HasOne(d => d.PedidoFkNavigation)
                    .WithMany(p => p.DetallePedido)
                    .HasForeignKey(d => d.PedidoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DetallePe__pedid__5BE2A6F2");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.NumeroCliente)
                    .HasName("PK__Empresa__DA2874623789EF19");

                entity.Property(e => e.NumeroCliente).ValueGeneratedNever();

                entity.Property(e => e.NombreEmpresa).IsUnicode(false);

                entity.Property(e => e.Representante).IsUnicode(false);

                entity.Property(e => e.Ruc).IsUnicode(false);

                entity.HasOne(d => d.NumeroClienteNavigation)
                    .WithOne(p => p.Empresa)
                    .HasForeignKey<Empresa>(d => d.NumeroCliente)
                    .HasConstraintName("FK__Empresa__numero___4E88ABD4");
            });

            modelBuilder.Entity<EstructuraMaterialesBom>(entity =>
            {
                entity.HasKey(e => e.CodBom)
                    .HasName("PK__Estructu__FD1B5E7BA3A1C2D8");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.MateriaPrimaFkNavigation)
                    .WithMany(p => p.EstructuraMaterialesBom)
                    .HasForeignKey(d => d.MateriaPrimaFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Estructur__mater__0F624AF8");

                entity.HasOne(d => d.ModeloProductoFkNavigation)
                    .WithMany(p => p.EstructuraMaterialesBom)
                    .HasForeignKey(d => d.ModeloProductoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Estructur__model__10566F31");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.CodInsumo)
                    .HasName("PK__Insumo__72BC4A8886A0340E");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NombreInsumo).IsUnicode(false);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.CodInventario)
                    .HasName("PK__Inventar__C117239A45F2C627");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.AgregadoFkNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.AgregadoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Inventari__agreg__1332DBDC");
            });

            modelBuilder.Entity<LineaProduccion>(entity =>
            {
                entity.HasKey(e => e.NumeroLineaProduccion)
                    .HasName("PK__LineaPro__5126622EFD6E624F");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NombreLineaProduccion).IsUnicode(false);
            });

            modelBuilder.Entity<MateriaPrima>(entity =>
            {
                entity.HasKey(e => e.CodMateriaPrima)
                    .HasName("PK__MateriaP__8262F779239DF52C");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.HasOne(d => d.InsumoFkNavigation)
                    .WithMany(p => p.MateriaPrima)
                    .HasForeignKey(d => d.InsumoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MateriaPr__insum__08B54D69");

                entity.HasOne(d => d.UnidadMedidaFkNavigation)
                    .WithMany(p => p.MateriaPrima)
                    .HasForeignKey(d => d.UnidadMedidaFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__MateriaPr__unida__09A971A2");
            });

            modelBuilder.Entity<ModeloProducto>(entity =>
            {
                entity.HasKey(e => e.CodEstructuraMateria)
                    .HasName("PK__ModeloPr__A480511FE32FE033");

                entity.Property(e => e.CodigoProducto).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NombreModelo).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.Property(e => e.TamanoEstandar).IsUnicode(false);

                entity.HasOne(d => d.LineaProduccionFkNavigation)
                    .WithMany(p => p.ModeloProducto)
                    .HasForeignKey(d => d.LineaProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ModeloPro__linea__59063A47");
            });

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.HasKey(e => e.CodMovimientoInventario)
                    .HasName("PK__Movimien__89910E5B993312B1");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Factura).IsUnicode(false);

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.Property(e => e.TipoMovimiento).IsUnicode(false);

                entity.HasOne(d => d.InventarioFkNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.InventarioFk)
                    .HasConstraintName("FK__Movimient__inven__1DB06A4F");

                entity.HasOne(d => d.OrdenAprovisionamientoFkNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.OrdenAprovisionamientoFk)
                    .HasConstraintName("FK__Movimient__orden__1F98B2C1");

                entity.HasOne(d => d.ProveedorFkNavigation)
                    .WithMany(p => p.MovimientoInventario)
                    .HasForeignKey(d => d.ProveedorFk)
                    .HasConstraintName("FK__Movimient__prove__1EA48E88");
            });

            modelBuilder.Entity<NoConformidad>(entity =>
            {
                entity.HasKey(e => e.CodNoConformidad)
                    .HasName("PK__NoConfor__823817DF60383558");

                entity.Property(e => e.DescripcionNoConformidad).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.ProcesoFkNavigation)
                    .WithMany(p => p.NoConformidad)
                    .HasForeignKey(d => d.ProcesoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__NoConform__proce__7B5B524B");
            });

            modelBuilder.Entity<OrdenAprovisionamiento>(entity =>
            {
                entity.HasKey(e => e.NumeroOrdenAprovisionamiento)
                    .HasName("PK__OrdenApr__947A2E27C09663E0");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Observacion).IsUnicode(false);
            });

            modelBuilder.Entity<OrdenProduccion>(entity =>
            {
                entity.HasKey(e => e.NumeroTarjetaFabricacion)
                    .HasName("PK__OrdenPro__6F9C2C8232BD01C0");

                entity.Property(e => e.Corrida).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.HasOne(d => d.PlanMaestroProduccionDetalladoFkNavigation)
                    .WithMany(p => p.OrdenProduccion)
                    .HasForeignKey(d => d.PlanMaestroProduccionDetalladoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__OrdenProd__plan___6EF57B66");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NumeroOrdenCompra)
                    .HasName("PK__Pedido__6481E6FF5183D7AA");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NumeroNotaPedido).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.HasOne(d => d.ClienteFkNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.ClienteFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Pedido__cliente___534D60F1");

                entity.HasOne(d => d.VendedorFkNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.VendedorFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Pedido__vendedor__5441852A");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.NumeroCliente)
                    .HasName("PK__Persona__DA287462BB0C368A");

                entity.Property(e => e.NumeroCliente).ValueGeneratedNever();

                entity.Property(e => e.NombreCliente).IsUnicode(false);

                entity.Property(e => e.NumeroCedula).IsUnicode(false);

                entity.HasOne(d => d.NumeroClienteNavigation)
                    .WithOne(p => p.Persona)
                    .HasForeignKey<Persona>(d => d.NumeroCliente)
                    .HasConstraintName("FK__Persona__numero___4BAC3F29");
            });

            modelBuilder.Entity<PlanMaestroProduccion>(entity =>
            {
                entity.HasKey(e => e.NumeroIngreso)
                    .HasName("PK__PlanMaes__E4D17A3472A832F0");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.HasOne(d => d.DetallePedidoFkNavigation)
                    .WithMany(p => p.PlanMaestroProduccion)
                    .HasForeignKey(d => d.DetallePedidoFk)
                    .HasConstraintName("FK__PlanMaest__detal__693CA210");

                entity.HasOne(d => d.LineaProduccionFkNavigation)
                    .WithMany(p => p.PlanMaestroProduccion)
                    .HasForeignKey(d => d.LineaProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PlanMaest__linea__68487DD7");
            });

            modelBuilder.Entity<PlanMaestroProduccionDetallado>(entity =>
            {
                entity.HasKey(e => e.NumeroIngreso)
                    .HasName("PK__PlanMaes__E4D17A34F0D6B101");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Observaciones).IsUnicode(false);

                entity.HasOne(d => d.PlanMaestroProduccionFkNavigation)
                    .WithMany(p => p.PlanMaestroProduccionDetallado)
                    .HasForeignKey(d => d.PlanMaestroProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PlanMaest__plan___6C190EBB");
            });

            modelBuilder.Entity<PlanificacionProyeccionMensual>(entity =>
            {
                entity.HasKey(e => e.Anio)
                    .HasName("PK__Planific__61B22F47AF885FBE");

                entity.Property(e => e.Anio).ValueGeneratedNever();

                entity.Property(e => e.Digitador).IsUnicode(false);
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.CodProceso)
                    .HasName("PK__Proceso__2766286A30BEB0EE");

                entity.Property(e => e.DescripcionProceso).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NombreProceso).IsUnicode(false);

                entity.HasOne(d => d.LineaProduccionFkNavigation)
                    .WithMany(p => p.Proceso)
                    .HasForeignKey(d => d.LineaProduccionFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Proceso__linea_p__71D1E811");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.NumeroProveedor)
                    .HasName("PK__Proveedo__46389B1FF80FBB44");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.NombreProveedor).IsUnicode(false);

                entity.Property(e => e.NumeroCedulaRuc).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TelefonoCelular).IsUnicode(false);
            });

            modelBuilder.Entity<TiempoProduccion>(entity =>
            {
                entity.HasKey(e => e.NumeroIngresoT)
                    .HasName("PK__TiempoPr__76D9FA3A4B7D4349");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.HasOne(d => d.ProcesoFkNavigation)
                    .WithMany(p => p.TiempoProduccion)
                    .HasForeignKey(d => d.ProcesoFk)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TiempoPro__proce__02084FDA");
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.HasKey(e => e.CodUnidadMedida)
                    .HasName("PK__UnidadMe__707C839684C4E587");

                entity.Property(e => e.Abreviatura).IsUnicode(false);

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.NombreUnidadMedida).IsUnicode(false);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.NumeroVendedor)
                    .HasName("PK__Vendedor__C64BE7BAF9B04D45");

                entity.Property(e => e.Digitador).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.NombreVendedor).IsUnicode(false);

                entity.Property(e => e.NumeroCedula).IsUnicode(false);

                entity.Property(e => e.NumeroRuc).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TelefonoCelular).IsUnicode(false);
            });


            //modelBuilder.Entity<Cliente>().Property(a => a.FechaIngreso).HasDefaultValueSql("Convert(date,Getdate())").ValueGeneratedOnAddOrUpdate();
            //modelBuilder.Entity<Cliente>().Property(a => a.FechaDigitador).HasDefaultValueSql("Convert(date,Getdate())").ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<Proveedor>().Property(a => a.FechaDigitador).HasDefaultValueSql("Convert(date,Getdate())").ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<Vendedor>().Property(a => a.FechaDigitador).HasDefaultValueSql("Convert(date,Getdate())").ValueGeneratedOnAddOrUpdate();
        }
    }
}
