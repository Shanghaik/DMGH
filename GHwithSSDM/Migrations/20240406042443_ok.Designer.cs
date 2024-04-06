﻿// <auto-generated />
using System;
using GHwithSSDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GHwithSSDM.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240406042443_ok")]
    partial class ok
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GHwithSSDM.Models.GHCT", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("IdGH")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdGH");

                    b.HasIndex("IdSP");

                    b.ToTable("GHCTs");
                });

            modelBuilder.Entity("GHwithSSDM.Models.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("GHwithSSDM.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("GHwithSSDM.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GHwithSSDM.Models.GHCT", b =>
                {
                    b.HasOne("GHwithSSDM.Models.GioHang", "GioHang")
                        .WithMany("GHCTs")
                        .HasForeignKey("IdGH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHwithSSDM.Models.SanPham", "SanPham")
                        .WithMany("GHCT")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("GHwithSSDM.Models.GioHang", b =>
                {
                    b.Navigation("GHCTs");
                });

            modelBuilder.Entity("GHwithSSDM.Models.SanPham", b =>
                {
                    b.Navigation("GHCT");
                });
#pragma warning restore 612, 618
        }
    }
}
