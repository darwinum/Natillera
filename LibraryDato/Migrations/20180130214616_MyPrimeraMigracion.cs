using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LibraryDato.Migrations
{
    public partial class MyPrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Natilleras",
                columns: table => new
                {
                    NatilleraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionNatillera = table.Column<string>(maxLength: 250, nullable: false),
                    DiasGraciaMora = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaInicioPagoCuota = table.Column<DateTime>(nullable: false),
                    NumeroCuotas = table.Column<int>(nullable: false),
                    TipoPago = table.Column<int>(nullable: false),
                    ValorCuota = table.Column<decimal>(nullable: false),
                    ValorMora = table.Column<decimal>(nullable: false),
                    ValorMoraDiaFijo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natilleras", x => x.NatilleraId);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentos", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    SocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(maxLength: 250, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(maxLength: 150, nullable: true),
                    Direccion = table.Column<string>(maxLength: 250, nullable: true),
                    Nombres = table.Column<string>(maxLength: 200, nullable: true),
                    NumeroDocumento = table.Column<string>(maxLength: 20, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    TiposDocumentoTipoDocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.SocioId);
                    table.ForeignKey(
                        name: "FK_Socios_TiposDocumentos_TiposDocumentoTipoDocumentoId",
                        column: x => x.TiposDocumentoTipoDocumentoId,
                        principalTable: "TiposDocumentos",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesRecaudos",
                columns: table => new
                {
                    ActividadesRecaudoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionActividad = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaRealizaActividad = table.Column<DateTime>(nullable: false),
                    NatilleraId = table.Column<int>(nullable: true),
                    SocioId = table.Column<int>(nullable: true),
                    ValorInvertido = table.Column<decimal>(nullable: false),
                    ValorNetoGanancia = table.Column<decimal>(nullable: false),
                    ValorRecaudado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesRecaudos", x => x.ActividadesRecaudoId);
                    table.ForeignKey(
                        name: "FK_ActividadesRecaudos_Natilleras_NatilleraId",
                        column: x => x.NatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActividadesRecaudos_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuotasSocios",
                columns: table => new
                {
                    CuotasSocioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaPagoCuota = table.Column<DateTime>(nullable: false),
                    NatilleraId = table.Column<int>(nullable: true),
                    SocioId = table.Column<int>(nullable: true),
                    ValorCuota = table.Column<decimal>(nullable: false),
                    ValorMulta = table.Column<decimal>(nullable: false),
                    ValorTotalCuota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasSocios", x => x.CuotasSocioId);
                    table.ForeignKey(
                        name: "FK_CuotasSocios_Natilleras_NatilleraId",
                        column: x => x.NatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuotasSocios_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NatilleraSocio",
                columns: table => new
                {
                    NatilleraSocioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NatilleraId = table.Column<int>(nullable: true),
                    SocioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatilleraSocio", x => x.NatilleraSocioID);
                    table.ForeignKey(
                        name: "FK_NatilleraSocio_Natilleras_NatilleraId",
                        column: x => x.NatilleraId,
                        principalTable: "Natilleras",
                        principalColumn: "NatilleraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NatilleraSocio_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaDesembolso = table.Column<DateTime>(nullable: false),
                    PorcentajeInteres = table.Column<int>(nullable: false),
                    ResponsablePagoPrestamo = table.Column<string>(maxLength: 250, nullable: true),
                    SocioId = table.Column<int>(nullable: true),
                    ValorCuotasNatillaActual = table.Column<decimal>(nullable: false),
                    ValorPrestado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "SocioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuotasPrestamos",
                columns: table => new
                {
                    CuotasPrestamoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiasMora = table.Column<int>(nullable: false),
                    FechaEsperaPago = table.Column<DateTime>(nullable: false),
                    FechaLimitePago = table.Column<DateTime>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: true),
                    ValorCuota = table.Column<decimal>(nullable: false),
                    ValorDiasMora = table.Column<decimal>(nullable: false),
                    ValorInteres = table.Column<decimal>(nullable: false),
                    ValorNetoPagoCuota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasPrestamos", x => x.CuotasPrestamoId);
                    table.ForeignKey(
                        name: "FK_CuotasPrestamos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesRecaudos_NatilleraId",
                table: "ActividadesRecaudos",
                column: "NatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesRecaudos_SocioId",
                table: "ActividadesRecaudos",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasPrestamos_PrestamoId",
                table: "CuotasPrestamos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasSocios_NatilleraId",
                table: "CuotasSocios",
                column: "NatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasSocios_SocioId",
                table: "CuotasSocios",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocio_NatilleraId",
                table: "NatilleraSocio",
                column: "NatilleraId");

            migrationBuilder.CreateIndex(
                name: "IX_NatilleraSocio_SocioId",
                table: "NatilleraSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SocioId",
                table: "Prestamos",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_TiposDocumentoTipoDocumentoId",
                table: "Socios",
                column: "TiposDocumentoTipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesRecaudos");

            migrationBuilder.DropTable(
                name: "CuotasPrestamos");

            migrationBuilder.DropTable(
                name: "CuotasSocios");

            migrationBuilder.DropTable(
                name: "NatilleraSocio");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Natilleras");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");
        }
    }
}
