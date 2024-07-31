﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using newLibrary.Data;

#nullable disable

namespace newLibrary.Migrations
{
    [DbContext(typeof(newLibraryDbContext))]
    [Migration("20240726042558_saveUserAnggota")]
    partial class saveUserAnggota
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("newLibrary.Models.Entities.Anggota", b =>
                {
                    b.Property<Guid>("Id_anggota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("tgl_gabung")
                        .HasColumnType("date");

                    b.HasKey("Id_anggota");

                    b.ToTable("Anggotas");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Buku", b =>
                {
                    b.Property<Guid>("Id_buku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<Guid>("Id_kategori")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Judul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Penerbit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Penulis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tahun_terbit")
                        .HasColumnType("int");

                    b.HasKey("Id_buku");

                    b.HasIndex("Id_kategori");

                    b.ToTable("Bukus");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Kategori", b =>
                {
                    b.Property<Guid>("Id_kategori")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nama_kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deskripsi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_kategori");

                    b.ToTable("Kategoris");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Peminjaman", b =>
                {
                    b.Property<Guid>("Id_peminjaman")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_anggota")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("tgl_kembali")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("tgl_pinjam")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_peminjaman");

                    b.HasIndex("Id_anggota");

                    b.HasIndex("Id_user");

                    b.ToTable("Peminjaman");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_user");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Buku", b =>
                {
                    b.HasOne("newLibrary.Models.Entities.Kategori", "Kategori")
                        .WithMany("Bukus")
                        .HasForeignKey("Id_kategori")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Peminjaman", b =>
                {
                    b.HasOne("newLibrary.Models.Entities.Anggota", "Anggota")
                        .WithMany("Peminjamans")
                        .HasForeignKey("Id_anggota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newLibrary.Models.Entities.User", "User")
                        .WithMany("Peminjamans")
                        .HasForeignKey("Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anggota");

                    b.Navigation("User");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Anggota", b =>
                {
                    b.Navigation("Peminjamans");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.Kategori", b =>
                {
                    b.Navigation("Bukus");
                });

            modelBuilder.Entity("newLibrary.Models.Entities.User", b =>
                {
                    b.Navigation("Peminjamans");
                });
#pragma warning restore 612, 618
        }
    }
}
