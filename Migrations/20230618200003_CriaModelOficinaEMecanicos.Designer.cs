﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Revis;

#nullable disable

namespace Revis.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230618200003_CriaModelOficinaEMecanicos")]
    partial class CriaModelOficinaEMecanicos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Revis.Models.MecanicoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("categoriaDeManutencao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idade")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("oficinaid")
                        .HasColumnType("int");

                    b.Property<string>("resumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("oficinaid");

                    b.ToTable("Mecanicos");
                });

            modelBuilder.Entity("Revis.Models.OficinaModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpnj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Oficinas");
                });

            modelBuilder.Entity("Revis.Models.MecanicoModel", b =>
                {
                    b.HasOne("Revis.Models.OficinaModel", "oficina")
                        .WithMany("mecanicos")
                        .HasForeignKey("oficinaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("oficina");
                });

            modelBuilder.Entity("Revis.Models.OficinaModel", b =>
                {
                    b.Navigation("mecanicos");
                });
#pragma warning restore 612, 618
        }
    }
}