﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayer.Core.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.ProductFeatureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductEntityId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductEntityId = 1,
                            Width = 200
                        },
                        new
                        {
                            Id = 2,
                            Color = "Mavi",
                            Height = 100,
                            ProductEntityId = 2,
                            Width = 200
                        });
                });

            modelBuilder.Entity("NLayer.Core.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryEntityId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryEntityId = 1,
                            CreatedDate = new DateTime(2023, 1, 26, 0, 14, 9, 877, DateTimeKind.Local).AddTicks(4104),
                            Name = "Kalem-1",
                            Price = 200m,
                            Stok = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryEntityId = 1,
                            CreatedDate = new DateTime(2023, 1, 26, 0, 14, 9, 877, DateTimeKind.Local).AddTicks(4116),
                            Name = "Kalem-2",
                            Price = 300m,
                            Stok = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryEntityId = 1,
                            CreatedDate = new DateTime(2023, 1, 26, 0, 14, 9, 877, DateTimeKind.Local).AddTicks(4119),
                            Name = "Kalem-3",
                            Price = 600m,
                            Stok = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryEntityId = 2,
                            CreatedDate = new DateTime(2023, 1, 26, 0, 14, 9, 877, DateTimeKind.Local).AddTicks(4122),
                            Name = "Kitap-1",
                            Price = 300m,
                            Stok = 0
                        },
                        new
                        {
                            Id = 5,
                            CategoryEntityId = 2,
                            CreatedDate = new DateTime(2023, 1, 26, 0, 14, 9, 877, DateTimeKind.Local).AddTicks(4125),
                            Name = "Kitap-2",
                            Price = 300m,
                            Stok = 0
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.ProductFeatureEntity", b =>
                {
                    b.HasOne("NLayer.Core.ProductEntity", "ProductEntity")
                        .WithOne("ProductFeatureEntity")
                        .HasForeignKey("NLayer.Core.Models.ProductFeatureEntity", "ProductEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductEntity");
                });

            modelBuilder.Entity("NLayer.Core.ProductEntity", b =>
                {
                    b.HasOne("NLayer.Core.CategoryEntity", "CategoryEntity")
                        .WithMany("ProductEntities")
                        .HasForeignKey("CategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryEntity");
                });

            modelBuilder.Entity("NLayer.Core.CategoryEntity", b =>
                {
                    b.Navigation("ProductEntities");
                });

            modelBuilder.Entity("NLayer.Core.ProductEntity", b =>
                {
                    b.Navigation("ProductFeatureEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
