﻿// <auto-generated />
using LibraryDato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LibraryDato.Migrations
{
    [DbContext(typeof(LibraryDatoContext))]
    [Migration("20180117175835_MyPrimeraMigracion")]
    partial class MyPrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryDato.Models.ActividadesRecaudo", b =>
                {
                    b.Property<int>("ActividadesRecaudoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionActividad");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaRealizaActividad");

                    b.Property<int?>("NatilleraId");

                    b.Property<int?>("SocioId");

                    b.Property<decimal>("ValorInvertido");

                    b.Property<decimal>("ValorNetoGanancia");

                    b.Property<decimal>("ValorRecaudado");

                    b.HasKey("ActividadesRecaudoId");

                    b.HasIndex("NatilleraId");

                    b.HasIndex("SocioId");

                    b.ToTable("ActividadesRecaudos");
                });

            modelBuilder.Entity("LibraryDato.Models.CuotasPrestamo", b =>
                {
                    b.Property<int>("CuotasPrestamoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiasMora");

                    b.Property<DateTime>("FechaEsperaPago");

                    b.Property<DateTime>("FechaLimitePago");

                    b.Property<int?>("PrestamoId");

                    b.Property<decimal>("ValorCuota");

                    b.Property<decimal>("ValorDiasMora");

                    b.Property<decimal>("ValorInteres");

                    b.Property<decimal>("ValorNetoPagoCuota");

                    b.HasKey("CuotasPrestamoId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CuotasPrestamos");
                });

            modelBuilder.Entity("LibraryDato.Models.CuotasSocio", b =>
                {
                    b.Property<int>("CuotasSocioId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaPagoCuota");

                    b.Property<int?>("NatilleraId");

                    b.Property<int?>("SocioId");

                    b.Property<decimal>("ValorCuota");

                    b.Property<decimal>("ValorMulta");

                    b.Property<decimal>("ValorTotalCuota");

                    b.HasKey("CuotasSocioId");

                    b.HasIndex("NatilleraId");

                    b.HasIndex("SocioId");

                    b.ToTable("CuotasSocios");
                });

            modelBuilder.Entity("LibraryDato.Models.Natillera", b =>
                {
                    b.Property<int>("NatilleraId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionNatillera")
                        .HasMaxLength(250);

                    b.Property<decimal>("DiasGraciaMora");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaInicioPagoCuota");

                    b.Property<int>("NumeroCuotas");

                    b.Property<string>("TipoPago")
                        .HasMaxLength(250);

                    b.Property<decimal>("ValorCuota");

                    b.Property<decimal>("ValorMora");

                    b.Property<bool>("ValorMoraDiaFijo");

                    b.HasKey("NatilleraId");

                    b.ToTable("Natilleras");
                });

            modelBuilder.Entity("LibraryDato.Models.NatilleraSocio", b =>
                {
                    b.Property<int>("NatilleraSocioID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("NatilleraId");

                    b.Property<int?>("SocioId");

                    b.HasKey("NatilleraSocioID");

                    b.HasIndex("NatilleraId");

                    b.HasIndex("SocioId");

                    b.ToTable("NatilleraSocio");
                });

            modelBuilder.Entity("LibraryDato.Models.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaDesembolso");

                    b.Property<int>("PorcentajeInteres");

                    b.Property<string>("ResponsablePagoPrestamo")
                        .HasMaxLength(250);

                    b.Property<int?>("SocioId");

                    b.Property<decimal>("ValorCuotasNatillaActual");

                    b.Property<decimal>("ValorPrestado");

                    b.HasKey("PrestamoId");

                    b.HasIndex("SocioId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("LibraryDato.Models.Socio", b =>
                {
                    b.Property<int>("SocioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .HasMaxLength(250);

                    b.Property<string>("Celular")
                        .HasMaxLength(20);

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(150);

                    b.Property<string>("Direccion")
                        .HasMaxLength(250);

                    b.Property<string>("Nombres")
                        .HasMaxLength(200);

                    b.Property<string>("NumeroDocumento")
                        .HasMaxLength(20);

                    b.Property<string>("Telefono")
                        .HasMaxLength(20);

                    b.Property<int?>("TiposDocumentoTipoDocumentoId");

                    b.HasKey("SocioId");

                    b.HasIndex("TiposDocumentoTipoDocumentoId");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("LibraryDato.Models.TiposDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TiposDocumentos");
                });

            modelBuilder.Entity("LibraryDato.Models.ActividadesRecaudo", b =>
                {
                    b.HasOne("LibraryDato.Models.Natillera", "Natillera")
                        .WithMany()
                        .HasForeignKey("NatilleraId");

                    b.HasOne("LibraryDato.Models.Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId");
                });

            modelBuilder.Entity("LibraryDato.Models.CuotasPrestamo", b =>
                {
                    b.HasOne("LibraryDato.Models.Prestamo", "Prestamo")
                        .WithMany("CuotasPrestamo")
                        .HasForeignKey("PrestamoId");
                });

            modelBuilder.Entity("LibraryDato.Models.CuotasSocio", b =>
                {
                    b.HasOne("LibraryDato.Models.Natillera", "Natillera")
                        .WithMany("CuotasSocio")
                        .HasForeignKey("NatilleraId");

                    b.HasOne("LibraryDato.Models.Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId");
                });

            modelBuilder.Entity("LibraryDato.Models.NatilleraSocio", b =>
                {
                    b.HasOne("LibraryDato.Models.Natillera", "Natillera")
                        .WithMany("NatilleraSocio")
                        .HasForeignKey("NatilleraId");

                    b.HasOne("LibraryDato.Models.Socio", "socio")
                        .WithMany("NatilleraSocio")
                        .HasForeignKey("SocioId");
                });

            modelBuilder.Entity("LibraryDato.Models.Prestamo", b =>
                {
                    b.HasOne("LibraryDato.Models.Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId");
                });

            modelBuilder.Entity("LibraryDato.Models.Socio", b =>
                {
                    b.HasOne("LibraryDato.Models.TiposDocumento", "TiposDocumento")
                        .WithMany()
                        .HasForeignKey("TiposDocumentoTipoDocumentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
