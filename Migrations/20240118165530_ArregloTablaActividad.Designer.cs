﻿// <auto-generated />
using System;
using ClubDeportivoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClubDeportivoAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240118165530_ArregloTablaActividad")]
    partial class ArregloTablaActividad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClubDeportivoAPI.Models.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Apto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Alto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("HistoriaMedica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdSocio")
                        .HasColumnType("int");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Aptos");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Carnet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroCarnet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carnets");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<int?>("InscripcionId")
                        .HasColumnType("int");

                    b.Property<string>("MedioDePago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("PagoRealizado")
                        .HasColumnType("bit");

                    b.HasKey("Id", "FechaPago");

                    b.HasIndex("InscripcionId");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Inscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActividadId")
                        .HasColumnType("int");

                    b.Property<int?>("CarnetId")
                        .HasColumnType("int");

                    b.Property<int?>("SocioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActividadId");

                    b.HasIndex("CarnetId");

                    b.HasIndex("SocioId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Cuota", b =>
                {
                    b.HasOne("ClubDeportivoAPI.Models.Inscripcion", null)
                        .WithMany("Cuotas")
                        .HasForeignKey("InscripcionId");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Inscripcion", b =>
                {
                    b.HasOne("ClubDeportivoAPI.Models.Actividad", "Actividad")
                        .WithMany()
                        .HasForeignKey("ActividadId");

                    b.HasOne("ClubDeportivoAPI.Models.Carnet", "Carnet")
                        .WithMany()
                        .HasForeignKey("CarnetId");

                    b.HasOne("ClubDeportivoAPI.Models.Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("SocioId");

                    b.Navigation("Actividad");

                    b.Navigation("Carnet");

                    b.Navigation("Socio");
                });

            modelBuilder.Entity("ClubDeportivoAPI.Models.Inscripcion", b =>
                {
                    b.Navigation("Cuotas");
                });
#pragma warning restore 612, 618
        }
    }
}
