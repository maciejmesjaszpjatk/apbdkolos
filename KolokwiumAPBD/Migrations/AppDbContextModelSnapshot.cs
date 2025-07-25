﻿// <auto-generated />
using System;
using KolokwiumAPBD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KolokwiumAPBD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KolokwiumAPBD.Models.AvailableProgram", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailableProgramId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WashingMachineId")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("WashingMachineId");

                    b.ToTable("Available_Program");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            Price = 33.4m,
                            ProgramId = 1,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            Price = 48.7m,
                            ProgramId = 2,
                            WashingMachineId = 2
                        });
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            FirstName = "Maciej",
                            LastName = "Mesjasz",
                            PhoneNumber = "+48794287703"
                        });
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.PurchaseHistory", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Purchase_History");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            CustomerId = 1,
                            PurchaseDate = new DateTime(2025, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 5
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            CustomerId = 1,
                            PurchaseDate = new DateTime(2025, 6, 8, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.WashingMachine", b =>
                {
                    b.Property<int>("WashingMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WashingMachineId"));

                    b.Property<decimal>("MaxWeight")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WashingMachineId");

                    b.ToTable("WashingMachines");

                    b.HasData(
                        new
                        {
                            WashingMachineId = 1,
                            MaxWeight = 32.12m,
                            SerialNumber = "APBD1111/S123/15"
                        },
                        new
                        {
                            WashingMachineId = 2,
                            MaxWeight = 55.23m,
                            SerialNumber = "APBD1112/S123/24"
                        });
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.WashingProgram", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TemperatureCelcius")
                        .HasColumnType("int");

                    b.HasKey("ProgramId");

                    b.ToTable("Program");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            DurationMinutes = 69,
                            Name = "Quickie",
                            TemperatureCelcius = 30
                        },
                        new
                        {
                            ProgramId = 2,
                            DurationMinutes = 143,
                            Name = "CottonDestroyer",
                            TemperatureCelcius = 90
                        },
                        new
                        {
                            ProgramId = 3,
                            DurationMinutes = 90,
                            Name = "Synthetic",
                            TemperatureCelcius = 5
                        });
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.AvailableProgram", b =>
                {
                    b.HasOne("KolokwiumAPBD.Models.WashingProgram", "Program")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KolokwiumAPBD.Models.WashingMachine", "WashingMachine")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("WashingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");

                    b.Navigation("WashingMachine");
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.PurchaseHistory", b =>
                {
                    b.HasOne("KolokwiumAPBD.Models.AvailableProgram", "AvailableProgram")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("AvailableProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KolokwiumAPBD.Models.Customer", "Customer")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailableProgram");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.AvailableProgram", b =>
                {
                    b.Navigation("PurchaseHistories");
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.Customer", b =>
                {
                    b.Navigation("PurchaseHistories");
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.WashingMachine", b =>
                {
                    b.Navigation("AvailablePrograms");
                });

            modelBuilder.Entity("KolokwiumAPBD.Models.WashingProgram", b =>
                {
                    b.Navigation("AvailablePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
