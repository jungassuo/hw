﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaAPI.Data;

#nullable disable

namespace PizzaAPI.Migrations
{
    [DbContext(typeof(AddDbContext))]
    [Migration("20230927152635_create-tables")]
    partial class createtables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaAPI.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<string>("ToppingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PizzaAPI.Models.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ToppingsCount")
                        .HasColumnType("float");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("OrderHeader");
                });

            modelBuilder.Entity("PizzaAPI.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"));

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SizePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            SizeId = 1,
                            SizeName = "Small",
                            SizePrice = 8m
                        },
                        new
                        {
                            SizeId = 2,
                            SizeName = "Medium",
                            SizePrice = 10m
                        },
                        new
                        {
                            SizeId = 3,
                            SizeName = "Large",
                            SizePrice = 12m
                        });
                });

            modelBuilder.Entity("PizzaAPI.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tomatoes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Broccoli"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Red Pepper"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bacon"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Basil"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mushroom"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Onion"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Extra Cheese"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
