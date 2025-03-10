﻿// <auto-generated />
using System;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230302162752_v1.2")]
    partial class v12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cuestionarios");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EsCorrecta")
                        .HasColumnType("bit");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Activo")
                        .HasColumnType("int");

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Participante")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("RespuestasCuestionarios");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionarioDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RespuestaCuestionarioId")
                        .HasColumnType("int");

                    b.Property<int>("RespuestaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RespuestaCuestionarioId");

                    b.HasIndex("RespuestaId");

                    b.ToTable("RespuestasCuestionariosDetalle");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Cuestionario", "Cuestionario")
                        .WithMany("listPreguntas")
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Respuesta", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Pregunta", "Pregunta")
                        .WithMany("listRespuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionario", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Cuestionario", "Cuestionario")
                        .WithMany()
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionarioDetalle", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.RespuestaCuestionario", "RespuestaCuestionario")
                        .WithMany("ListCuestionarioDetalle")
                        .HasForeignKey("RespuestaCuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Domain.Models.Respuesta", "Respuesta")
                        .WithMany()
                        .HasForeignKey("RespuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Respuesta");

                    b.Navigation("RespuestaCuestionario");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Cuestionario", b =>
                {
                    b.Navigation("listPreguntas");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Pregunta", b =>
                {
                    b.Navigation("listRespuestas");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.RespuestaCuestionario", b =>
                {
                    b.Navigation("ListCuestionarioDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
