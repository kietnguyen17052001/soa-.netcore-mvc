﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManager.Models;

#nullable disable

namespace ProductManager.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220827072856_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductManager.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("float");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("productId");

                    b.ToTable("product");
                });
#pragma warning restore 612, 618
        }
    }
}
