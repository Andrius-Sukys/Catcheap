﻿// <auto-generated />
using System;
using Catcheap_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatcheapAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catcheap_API.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BatteryCapacity")
                        .HasColumnType("float");

                    b.Property<double>("BatteryLevel")
                        .HasColumnType("float");

                    b.Property<double>("Consumption")
                        .HasColumnType("float");

                    b.Property<int>("EngineHorsePowers")
                        .HasColumnType("int");

                    b.Property<double>("ExpectedRange")
                        .HasColumnType("float");

                    b.Property<DateTime>("MOTExpiry")
                        .HasColumnType("date");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Mileage")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Catcheap_API.Models.CarCharge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<double>("ChargingPower")
                        .HasColumnType("float");

                    b.Property<double>("ChargingPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndOfCharge")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfCharge")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarCharges");
                });

            modelBuilder.Entity("Catcheap_API.Models.CarJourney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarJourneys");
                });

            modelBuilder.Entity("Catcheap_API.Models.ChargingStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Holder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("StreetNumber")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("ChargingStations");
                });

            modelBuilder.Entity("Catcheap_API.Models.NordpoolPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("NordpoolPrices");
                });

            modelBuilder.Entity("Catcheap_API.Models.Scooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageSpeed")
                        .HasColumnType("float");

                    b.Property<double>("BatteryCapacity")
                        .HasColumnType("float");

                    b.Property<double>("BatteryLevel")
                        .HasColumnType("float");

                    b.Property<double>("Consumption")
                        .HasColumnType("float");

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<double>("ExpectedRange")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TopSpeed")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("WeightCapacity")
                        .HasColumnType("float");

                    b.Property<double>("WeightRider")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Scooters");
                });

            modelBuilder.Entity("Catcheap_API.Models.ScooterCharge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ChargingPower")
                        .HasColumnType("float");

                    b.Property<double>("ChargingPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndOfCharge")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScooterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartOfCharge")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScooterId");

                    b.ToTable("ScooterCharges");
                });

            modelBuilder.Entity("Catcheap_API.Models.ScooterJourney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScooterId")
                        .HasColumnType("int");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScooterId");

                    b.ToTable("ScooterJourneys");
                });

            modelBuilder.Entity("Catcheap_API.Models.CarCharge", b =>
                {
                    b.HasOne("Catcheap_API.Models.Car", "Car")
                        .WithMany("Charges")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Catcheap_API.Models.CarJourney", b =>
                {
                    b.HasOne("Catcheap_API.Models.Car", "Car")
                        .WithMany("Journeys")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Catcheap_API.Models.ScooterCharge", b =>
                {
                    b.HasOne("Catcheap_API.Models.Scooter", "Scooter")
                        .WithMany("Charges")
                        .HasForeignKey("ScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scooter");
                });

            modelBuilder.Entity("Catcheap_API.Models.ScooterJourney", b =>
                {
                    b.HasOne("Catcheap_API.Models.Scooter", "Scooter")
                        .WithMany("Journeys")
                        .HasForeignKey("ScooterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scooter");
                });

            modelBuilder.Entity("Catcheap_API.Models.Car", b =>
                {
                    b.Navigation("Charges");

                    b.Navigation("Journeys");
                });

            modelBuilder.Entity("Catcheap_API.Models.Scooter", b =>
                {
                    b.Navigation("Charges");

                    b.Navigation("Journeys");
                });
#pragma warning restore 612, 618
        }
    }
}
