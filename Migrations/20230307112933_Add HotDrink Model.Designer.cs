﻿// <auto-generated />
using CoffeeShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230307112933_Add HotDrink Model")]
    partial class AddHotDrinkModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoffeeShop.Models.HotDrink", b =>
                {
                    b.Property<int>("HotDrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotDrinkId"), 1L, 1);

                    b.Property<string>("HotDrinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotDrinkId");

                    b.ToTable("HotDrink");
                });
#pragma warning restore 612, 618
        }
    }
}
