﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrucksRegister.Models;

namespace TrucksRegister.Migrations
{
    [DbContext(typeof(TrucksContext))]
    [Migration("20221203180228_trucksDb")]
    partial class trucksDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrucksRegister.Models.Trucks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManufacturingYear")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<int?>("TrucksId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrucksId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("TrucksRegister.Models.Trucks", b =>
                {
                    b.HasOne("TrucksRegister.Models.Trucks", null)
                        .WithMany("Truck")
                        .HasForeignKey("TrucksId");
                });

            modelBuilder.Entity("TrucksRegister.Models.Trucks", b =>
                {
                    b.Navigation("Truck");
                });
#pragma warning restore 612, 618
        }
    }
}
