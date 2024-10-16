﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtoServisSatis.Data;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240817232420_anasayfaolsunmuEklendi")]
    partial class anasayfaolsunmuEklendi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OtoServisSatis.Entities.KasaTipis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KasaTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KasaTipis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KasaTipi = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            KasaTipi = "HatchBack"
                        },
                        new
                        {
                            Id = 3,
                            KasaTipi = "SUV"
                        },
                        new
                        {
                            Id = 4,
                            KasaTipi = "Pick-Up"
                        },
                        new
                        {
                            Id = 5,
                            KasaTipi = "Station"
                        });
                });

            modelBuilder.Entity("OtoServisSatis.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Baslik")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Link")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Arac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AnaSayfadaMi")
                        .HasColumnType("bit");

                    b.Property<decimal>("Fiyati")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KasaTipisId")
                        .HasColumnType("int");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int>("ModelYili")
                        .HasColumnType("int");

                    b.Property<string>("Modeli")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Renk")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Resim1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resim3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("SatistaMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KasaTipisId");

                    b.HasIndex("MarkaId");

                    b.ToTable("Araclar");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciAdi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Admin",
                            AktifMi = true,
                            EklenmeTarihi = new DateTime(2024, 8, 18, 2, 24, 20, 66, DateTimeKind.Local).AddTicks(517),
                            Email = "admin@otoservissatis.tc",
                            RolId = 1,
                            Sifre = "123456",
                            Soyadi = "admin",
                            Telefon = "0850"
                        });
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Markalar");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Adres")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("AracId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notlar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TcNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefon")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AracId");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roller");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Admin"
                        });
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Satis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AracId")
                        .HasColumnType("int");

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.Property<decimal>("SatisFiyati")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SatisTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AracId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Satislar");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Servis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AracPlaka")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("AracSorunu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GarantiKapsamindaMi")
                        .HasColumnType("bit");

                    b.Property<string>("KasaTipi")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notlar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaseNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ServisUcreti")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ServiseGelisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ServistenCikisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("YapilanIslemler")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servisler");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Arac", b =>
                {
                    b.HasOne("OtoServisSatis.Entities.KasaTipis", "KasaTipis")
                        .WithMany()
                        .HasForeignKey("KasaTipisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtoServisSatis.Entity.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KasaTipis");

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Kullanici", b =>
                {
                    b.HasOne("OtoServisSatis.Entity.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Musteri", b =>
                {
                    b.HasOne("OtoServisSatis.Entity.Arac", "Arac")
                        .WithMany()
                        .HasForeignKey("AracId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arac");
                });

            modelBuilder.Entity("OtoServisSatis.Entity.Satis", b =>
                {
                    b.HasOne("OtoServisSatis.Entity.Arac", "Arac")
                        .WithMany()
                        .HasForeignKey("AracId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtoServisSatis.Entity.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arac");

                    b.Navigation("Musteri");
                });
#pragma warning restore 612, 618
        }
    }
}
