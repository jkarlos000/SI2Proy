using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SI2Proy.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    numero_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    direccion = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "Convert(date,Getdate())"),
                    telefono = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    telefono_celular = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    prioridad_cliente = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "Convert(date,Getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__DA28746217A07AC9", x => x.numero_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    cod_insumo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_insumo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insumo__72BC4A8886A0340E", x => x.cod_insumo);
                });

            migrationBuilder.CreateTable(
                name: "LineaProduccion",
                columns: table => new
                {
                    numero_linea_produccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_linea_produccion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(unicode: false, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LineaPro__5126622EFD6E624F", x => x.numero_linea_produccion);
                });

            migrationBuilder.CreateTable(
                name: "OrdenAprovisionamiento",
                columns: table => new
                {
                    numero_orden_aprovisionamiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha_emision = table.Column<DateTime>(type: "datetime", nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    fecha_estimada_entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    aprobado = table.Column<bool>(nullable: true),
                    aprobado_por = table.Column<string>(nullable: true),
                    estado_entregado = table.Column<bool>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrdenApr__947A2E27C09663E0", x => x.numero_orden_aprovisionamiento);
                });

            migrationBuilder.CreateTable(
                name: "PlanificacionProyeccionMensual",
                columns: table => new
                {
                    anio = table.Column<int>(nullable: false),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Planific__61B22F47AF885FBE", x => x.anio);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    numero_proveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero_cedula_ruc = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    nombre_proveedor = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    direccion = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    telefono_celular = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__46389B1FF80FBB44", x => x.numero_proveedor);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    cod_unidad_medida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_unidad_medida = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    abreviatura = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UnidadMe__707C839684C4E587", x => x.cod_unidad_medida);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    numero_vendedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero_cedula = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    numero_ruc = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    nombre_vendedor = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    direccion = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    telefono = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    telefono_celular = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    record_ventas = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vendedor__C64BE7BAF9B04D45", x => x.numero_vendedor);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    numero_cliente = table.Column<int>(nullable: false),
                    ruc = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    nombre_empresa = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    representante = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresa__DA2874623789EF19", x => x.numero_cliente);
                    table.ForeignKey(
                        name: "FK__Empresa__numero___4E88ABD4",
                        column: x => x.numero_cliente,
                        principalTable: "Cliente",
                        principalColumn: "numero_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    numero_cliente = table.Column<int>(nullable: false),
                    numero_cedula = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    nombre_cliente = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persona__DA287462BB0C368A", x => x.numero_cliente);
                    table.ForeignKey(
                        name: "FK__Persona__numero___4BAC3F29",
                        column: x => x.numero_cliente,
                        principalTable: "Cliente",
                        principalColumn: "numero_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloProducto",
                columns: table => new
                {
                    cod_estructura_materia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo_producto = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    nombre_modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tamano_estandar = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    precio_unitario = table.Column<int>(nullable: true),
                    observaciones = table.Column<string>(unicode: false, nullable: true),
                    estado = table.Column<bool>(nullable: true),
                    linea_produccion_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModeloPr__A480511FE32FE033", x => x.cod_estructura_materia);
                    table.ForeignKey(
                        name: "FK__ModeloPro__linea__59063A47",
                        column: x => x.linea_produccion_fk,
                        principalTable: "LineaProduccion",
                        principalColumn: "numero_linea_produccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proceso",
                columns: table => new
                {
                    cod_proceso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_proceso = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    descripcion_proceso = table.Column<string>(unicode: false, nullable: true),
                    linea_produccion_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proceso__2766286A30BEB0EE", x => x.cod_proceso);
                    table.ForeignKey(
                        name: "FK__Proceso__linea_p__71D1E811",
                        column: x => x.linea_produccion_fk,
                        principalTable: "LineaProduccion",
                        principalColumn: "numero_linea_produccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesgloseProyeccionProduccionMensual",
                columns: table => new
                {
                    numero_mes_ano = table.Column<int>(nullable: false),
                    numero_productos_proyectado_fabricar = table.Column<int>(nullable: true),
                    total_dias_laborales_mes = table.Column<int>(nullable: true),
                    total_producto_producir_mes = table.Column<int>(nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    planificacion_proyeccion_mensual_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Desglose__4D6FBD777FDF122F", x => x.numero_mes_ano);
                    table.ForeignKey(
                        name: "FK__DesgloseP__plani__619B8048",
                        column: x => x.planificacion_proyeccion_mensual_fk,
                        principalTable: "PlanificacionProyeccionMensual",
                        principalColumn: "anio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaPrima",
                columns: table => new
                {
                    cod_materia_prima = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(unicode: false, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    activo = table.Column<bool>(nullable: true),
                    tipo = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    insumo_fk = table.Column<int>(nullable: true),
                    unidad_medida_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MateriaP__8262F779239DF52C", x => x.cod_materia_prima);
                    table.ForeignKey(
                        name: "FK__MateriaPr__insum__08B54D69",
                        column: x => x.insumo_fk,
                        principalTable: "Insumo",
                        principalColumn: "cod_insumo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__MateriaPr__unida__09A971A2",
                        column: x => x.unidad_medida_fk,
                        principalTable: "UnidadMedida",
                        principalColumn: "cod_unidad_medida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    numero_orden_compra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero_nota_pedido = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    precio_total = table.Column<int>(nullable: true),
                    fecha_entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    observaciones = table.Column<string>(unicode: false, nullable: true),
                    fecha_real_entrega_pedido = table.Column<DateTime>(type: "datetime", nullable: true),
                    pedido_finalizado = table.Column<bool>(nullable: true),
                    cliente_fk = table.Column<int>(nullable: true),
                    vendedor_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedido__6481E6FF5183D7AA", x => x.numero_orden_compra);
                    table.ForeignKey(
                        name: "FK__Pedido__cliente___534D60F1",
                        column: x => x.cliente_fk,
                        principalTable: "Cliente",
                        principalColumn: "numero_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Pedido__vendedor__5441852A",
                        column: x => x.vendedor_fk,
                        principalTable: "Vendedor",
                        principalColumn: "numero_vendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoConformidad",
                columns: table => new
                {
                    cod_no_conformidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion_no_conformidad = table.Column<string>(unicode: false, nullable: true),
                    proceso_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NoConfor__823817DF60383558", x => x.cod_no_conformidad);
                    table.ForeignKey(
                        name: "FK__NoConform__proce__7B5B524B",
                        column: x => x.proceso_fk,
                        principalTable: "Proceso",
                        principalColumn: "cod_proceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiempoProduccion",
                columns: table => new
                {
                    numero_ingreso_t = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero_obreros = table.Column<int>(nullable: true),
                    fecha_jornada = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora_inicio_jornada = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora_fin_jornada = table.Column<DateTime>(type: "datetime", nullable: true),
                    tiempo_total_receso = table.Column<DateTime>(type: "datetime", nullable: true),
                    tiempo_laborado = table.Column<DateTime>(type: "datetime", nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    proceso_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiempoPr__76D9FA3A4B7D4349", x => x.numero_ingreso_t);
                    table.ForeignKey(
                        name: "FK__TiempoPro__proce__02084FDA",
                        column: x => x.proceso_fk,
                        principalTable: "Proceso",
                        principalColumn: "cod_proceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesgloseProyeccionLineaProduccion",
                columns: table => new
                {
                    cod_desglose_linea_produccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    porcentaje_produccion = table.Column<int>(nullable: true),
                    total_cant_producto_producir_mes_linea_produccion = table.Column<int>(nullable: true),
                    desglose_proyeccion_produccion_mensual_fk = table.Column<int>(nullable: true),
                    linea_produccion_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Desglose__4623E72D7CBF22E7", x => x.cod_desglose_linea_produccion);
                    table.ForeignKey(
                        name: "FK__DesgloseP__desgl__6477ECF3",
                        column: x => x.desglose_proyeccion_produccion_mensual_fk,
                        principalTable: "DesgloseProyeccionProduccionMensual",
                        principalColumn: "numero_mes_ano",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DesgloseP__linea__656C112C",
                        column: x => x.linea_produccion_fk,
                        principalTable: "LineaProduccion",
                        principalColumn: "numero_linea_produccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agregado",
                columns: table => new
                {
                    cod_materia_prima = table.Column<int>(nullable: false),
                    nombre_materia_prima = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agregado__8262F779A7566A38", x => x.cod_materia_prima);
                    table.ForeignKey(
                        name: "FK__Agregado__cod_ma__0C85DE4D",
                        column: x => x.cod_materia_prima,
                        principalTable: "MateriaPrima",
                        principalColumn: "cod_materia_prima",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstructuraMaterialesBom",
                columns: table => new
                {
                    cod_bom = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(unicode: false, nullable: true),
                    cantidad_por_producto = table.Column<int>(nullable: true),
                    fecha_vigencia = table.Column<DateTime>(type: "datetime", nullable: true),
                    obligatorio = table.Column<bool>(nullable: true),
                    materia_prima_fk = table.Column<int>(nullable: true),
                    modelo_producto_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estructu__FD1B5E7BA3A1C2D8", x => x.cod_bom);
                    table.ForeignKey(
                        name: "FK__Estructur__mater__0F624AF8",
                        column: x => x.materia_prima_fk,
                        principalTable: "MateriaPrima",
                        principalColumn: "cod_materia_prima",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Estructur__model__10566F31",
                        column: x => x.modelo_producto_fk,
                        principalTable: "ModeloProducto",
                        principalColumn: "cod_estructura_materia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    cod_detalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cantidad_detalle = table.Column<int>(nullable: true),
                    precio_total_detalle = table.Column<int>(nullable: true),
                    detalle_pedido_finalizado = table.Column<bool>(nullable: true),
                    pedido_fk = table.Column<int>(nullable: true),
                    modelo_producto_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleP__03E666AEB8CCCA85", x => x.cod_detalle);
                    table.ForeignKey(
                        name: "FK__DetallePe__model__5CD6CB2B",
                        column: x => x.modelo_producto_fk,
                        principalTable: "ModeloProducto",
                        principalColumn: "cod_estructura_materia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetallePe__pedid__5BE2A6F2",
                        column: x => x.pedido_fk,
                        principalTable: "Pedido",
                        principalColumn: "numero_orden_compra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    cod_inventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    total = table.Column<int>(nullable: true),
                    saldo_pro = table.Column<int>(nullable: true),
                    pedir_q = table.Column<int>(nullable: true),
                    stock_maximo = table.Column<int>(nullable: true),
                    stock_comprometido = table.Column<int>(nullable: true),
                    fecha_stock_comprometido = table.Column<DateTime>(type: "datetime", nullable: true),
                    agregado_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__C117239A45F2C627", x => x.cod_inventario);
                    table.ForeignKey(
                        name: "FK__Inventari__agreg__1332DBDC",
                        column: x => x.agregado_fk,
                        principalTable: "Agregado",
                        principalColumn: "cod_materia_prima",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaestroProduccion",
                columns: table => new
                {
                    numero_ingreso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    mes_anio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_prevista_ingreso_prod = table.Column<DateTime>(type: "datetime", nullable: true),
                    numero_lote = table.Column<int>(nullable: true),
                    observaciones = table.Column<string>(unicode: false, nullable: true),
                    linea_produccion_fk = table.Column<int>(nullable: true),
                    detalle_pedido_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanMaes__E4D17A3472A832F0", x => x.numero_ingreso);
                    table.ForeignKey(
                        name: "FK__PlanMaest__detal__693CA210",
                        column: x => x.detalle_pedido_fk,
                        principalTable: "DetallePedido",
                        principalColumn: "cod_detalle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PlanMaest__linea__68487DD7",
                        column: x => x.linea_produccion_fk,
                        principalTable: "LineaProduccion",
                        principalColumn: "numero_linea_produccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleAprovisionamiento",
                columns: table => new
                {
                    cod_detalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(nullable: true),
                    ingresado = table.Column<bool>(nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    orden_aprovisionamiento_fk = table.Column<int>(nullable: true),
                    inventario_fk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleA__03E666AE79BED8D2", x => x.cod_detalle);
                    table.ForeignKey(
                        name: "FK__DetalleAp__inven__1AD3FDA4",
                        column: x => x.inventario_fk,
                        principalTable: "Inventario",
                        principalColumn: "cod_inventario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleAp__orden__19DFD96B",
                        column: x => x.orden_aprovisionamiento_fk,
                        principalTable: "OrdenAprovisionamiento",
                        principalColumn: "numero_orden_aprovisionamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoInventario",
                columns: table => new
                {
                    cod_movimiento_inventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo_movimiento = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    fecha_movimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    factura = table.Column<string>(unicode: false, nullable: true),
                    precio_unitario = table.Column<int>(nullable: true),
                    cantidad = table.Column<int>(nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    inventario_fk = table.Column<int>(nullable: true),
                    proveedor_fk = table.Column<int>(nullable: true),
                    orden_aprovisionamiento_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movimien__89910E5B993312B1", x => x.cod_movimiento_inventario);
                    table.ForeignKey(
                        name: "FK__Movimient__inven__1DB06A4F",
                        column: x => x.inventario_fk,
                        principalTable: "Inventario",
                        principalColumn: "cod_inventario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Movimient__orden__1F98B2C1",
                        column: x => x.orden_aprovisionamiento_fk,
                        principalTable: "OrdenAprovisionamiento",
                        principalColumn: "numero_orden_aprovisionamiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Movimient__prove__1EA48E88",
                        column: x => x.proveedor_fk,
                        principalTable: "Proveedor",
                        principalColumn: "numero_proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaestroProduccionDetallado",
                columns: table => new
                {
                    numero_ingreso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dia = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_ingreso_hoja_ruta = table.Column<DateTime>(type: "datetime", nullable: true),
                    observaciones = table.Column<string>(unicode: false, nullable: true),
                    plan_maestro_produccion_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlanMaes__E4D17A34F0D6B101", x => x.numero_ingreso);
                    table.ForeignKey(
                        name: "FK__PlanMaest__plan___6C190EBB",
                        column: x => x.plan_maestro_produccion_fk,
                        principalTable: "PlanMaestroProduccion",
                        principalColumn: "numero_ingreso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenProduccion",
                columns: table => new
                {
                    numero_tarjeta_fabricacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cerco = table.Column<bool>(nullable: true),
                    corrida = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora_creacion = table.Column<TimeSpan>(nullable: true),
                    plan_maestro_produccion_detallado_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrdenPro__6F9C2C8232BD01C0", x => x.numero_tarjeta_fabricacion);
                    table.ForeignKey(
                        name: "FK__OrdenProd__plan___6EF57B66",
                        column: x => x.plan_maestro_produccion_detallado_fk,
                        principalTable: "PlanMaestroProduccionDetallado",
                        principalColumn: "numero_ingreso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenProduccion",
                columns: table => new
                {
                    cod_detalle_orden = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora_fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    observacion = table.Column<string>(unicode: false, nullable: true),
                    control_calidad = table.Column<bool>(nullable: true),
                    orden_produccion_fk = table.Column<int>(nullable: true),
                    proceso_fk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleO__6EA4E1E7508AB731", x => x.cod_detalle_orden);
                    table.ForeignKey(
                        name: "FK__DetalleOr__orden__74AE54BC",
                        column: x => x.orden_produccion_fk,
                        principalTable: "OrdenProduccion",
                        principalColumn: "numero_tarjeta_fabricacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DetalleOr__proce__75A278F5",
                        column: x => x.proceso_fk,
                        principalTable: "Proceso",
                        principalColumn: "cod_proceso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlCalidad",
                columns: table => new
                {
                    numero_control_calidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    tamano_lote = table.Column<int>(nullable: true),
                    tamano_muestra = table.Column<int>(nullable: true),
                    total_defectos = table.Column<int>(nullable: true),
                    detalle_orden_produccion_fk = table.Column<int>(nullable: true),
                    digitador = table.Column<string>(unicode: false, nullable: true),
                    fecha_digitador = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ControlC__CBF8F5AEFFE67087", x => x.numero_control_calidad);
                    table.ForeignKey(
                        name: "FK__ControlCa__detal__787EE5A0",
                        column: x => x.detalle_orden_produccion_fk,
                        principalTable: "DetalleOrdenProduccion",
                        principalColumn: "cod_detalle_orden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleControlCalidad",
                columns: table => new
                {
                    cod_detalle_control_calidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    total_no_conformidad = table.Column<int>(nullable: true),
                    control_calidad_fk = table.Column<int>(nullable: true),
                    no_conformidad_fk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleC__E6A8A05BAE951F38", x => x.cod_detalle_control_calidad);
                    table.ForeignKey(
                        name: "FK__DetalleCo__contr__7E37BEF6",
                        column: x => x.control_calidad_fk,
                        principalTable: "ControlCalidad",
                        principalColumn: "numero_control_calidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleCo__no_co__7F2BE32F",
                        column: x => x.no_conformidad_fk,
                        principalTable: "NoConformidad",
                        principalColumn: "cod_no_conformidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlCalidad_detalle_orden_produccion_fk",
                table: "ControlCalidad",
                column: "detalle_orden_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DesgloseProyeccionLineaProduccion_desglose_proyeccion_produccion_mensual_fk",
                table: "DesgloseProyeccionLineaProduccion",
                column: "desglose_proyeccion_produccion_mensual_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DesgloseProyeccionLineaProduccion_linea_produccion_fk",
                table: "DesgloseProyeccionLineaProduccion",
                column: "linea_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DesgloseProyeccionProduccionMensual_planificacion_proyeccion_mensual_fk",
                table: "DesgloseProyeccionProduccionMensual",
                column: "planificacion_proyeccion_mensual_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAprovisionamiento_inventario_fk",
                table: "DetalleAprovisionamiento",
                column: "inventario_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAprovisionamiento_orden_aprovisionamiento_fk",
                table: "DetalleAprovisionamiento",
                column: "orden_aprovisionamiento_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleControlCalidad_control_calidad_fk",
                table: "DetalleControlCalidad",
                column: "control_calidad_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleControlCalidad_no_conformidad_fk",
                table: "DetalleControlCalidad",
                column: "no_conformidad_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenProduccion_orden_produccion_fk",
                table: "DetalleOrdenProduccion",
                column: "orden_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenProduccion_proceso_fk",
                table: "DetalleOrdenProduccion",
                column: "proceso_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_modelo_producto_fk",
                table: "DetallePedido",
                column: "modelo_producto_fk");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_pedido_fk",
                table: "DetallePedido",
                column: "pedido_fk");

            migrationBuilder.CreateIndex(
                name: "IX_EstructuraMaterialesBom_materia_prima_fk",
                table: "EstructuraMaterialesBom",
                column: "materia_prima_fk");

            migrationBuilder.CreateIndex(
                name: "IX_EstructuraMaterialesBom_modelo_producto_fk",
                table: "EstructuraMaterialesBom",
                column: "modelo_producto_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_agregado_fk",
                table: "Inventario",
                column: "agregado_fk");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaPrima_insumo_fk",
                table: "MateriaPrima",
                column: "insumo_fk");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaPrima_unidad_medida_fk",
                table: "MateriaPrima",
                column: "unidad_medida_fk");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloProducto_linea_produccion_fk",
                table: "ModeloProducto",
                column: "linea_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventario_inventario_fk",
                table: "MovimientoInventario",
                column: "inventario_fk");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventario_orden_aprovisionamiento_fk",
                table: "MovimientoInventario",
                column: "orden_aprovisionamiento_fk");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventario_proveedor_fk",
                table: "MovimientoInventario",
                column: "proveedor_fk");

            migrationBuilder.CreateIndex(
                name: "IX_NoConformidad_proceso_fk",
                table: "NoConformidad",
                column: "proceso_fk");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProduccion_plan_maestro_produccion_detallado_fk",
                table: "OrdenProduccion",
                column: "plan_maestro_produccion_detallado_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_cliente_fk",
                table: "Pedido",
                column: "cliente_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_vendedor_fk",
                table: "Pedido",
                column: "vendedor_fk");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaestroProduccion_detalle_pedido_fk",
                table: "PlanMaestroProduccion",
                column: "detalle_pedido_fk");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaestroProduccion_linea_produccion_fk",
                table: "PlanMaestroProduccion",
                column: "linea_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaestroProduccionDetallado_plan_maestro_produccion_fk",
                table: "PlanMaestroProduccionDetallado",
                column: "plan_maestro_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Proceso_linea_produccion_fk",
                table: "Proceso",
                column: "linea_produccion_fk");

            migrationBuilder.CreateIndex(
                name: "IX_TiempoProduccion_proceso_fk",
                table: "TiempoProduccion",
                column: "proceso_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesgloseProyeccionLineaProduccion");

            migrationBuilder.DropTable(
                name: "DetalleAprovisionamiento");

            migrationBuilder.DropTable(
                name: "DetalleControlCalidad");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "EstructuraMaterialesBom");

            migrationBuilder.DropTable(
                name: "MovimientoInventario");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TiempoProduccion");

            migrationBuilder.DropTable(
                name: "DesgloseProyeccionProduccionMensual");

            migrationBuilder.DropTable(
                name: "ControlCalidad");

            migrationBuilder.DropTable(
                name: "NoConformidad");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "OrdenAprovisionamiento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "PlanificacionProyeccionMensual");

            migrationBuilder.DropTable(
                name: "DetalleOrdenProduccion");

            migrationBuilder.DropTable(
                name: "Agregado");

            migrationBuilder.DropTable(
                name: "OrdenProduccion");

            migrationBuilder.DropTable(
                name: "Proceso");

            migrationBuilder.DropTable(
                name: "MateriaPrima");

            migrationBuilder.DropTable(
                name: "PlanMaestroProduccionDetallado");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "PlanMaestroProduccion");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "ModeloProducto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "LineaProduccion");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
