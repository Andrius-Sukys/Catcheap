using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatcheapAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    EngineHorsePowers = table.Column<int>(type: "int", nullable: false),
                    MOTExpiry = table.Column<DateTime>(type: "date", nullable: false),
                    ExpectedRange = table.Column<double>(type: "float", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "float", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    BatteryLevel = table.Column<double>(type: "float", nullable: false),
                    Mileage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargingStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Holder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NordpoolPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NordpoolPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scooters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false),
                    ExpectedRange = table.Column<double>(type: "float", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "float", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    BatteryLevel = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    WeightCapacity = table.Column<double>(type: "float", nullable: false),
                    WeightRider = table.Column<double>(type: "float", nullable: false),
                    AverageSpeed = table.Column<double>(type: "float", nullable: false),
                    TopSpeed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargingPower = table.Column<double>(type: "float", nullable: false),
                    StartOfCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCharges_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarJourneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarJourneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarJourneys_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScooterCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargingPower = table.Column<double>(type: "float", nullable: false),
                    StartOfCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScooterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScooterCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScooterCharges_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScooterJourneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    ScooterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScooterJourneys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScooterJourneys_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCharges_CarId",
                table: "CarCharges",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarJourneys_CarId",
                table: "CarJourneys",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterCharges_ScooterId",
                table: "ScooterCharges",
                column: "ScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterJourneys_ScooterId",
                table: "ScooterJourneys",
                column: "ScooterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCharges");

            migrationBuilder.DropTable(
                name: "CarJourneys");

            migrationBuilder.DropTable(
                name: "ChargingStations");

            migrationBuilder.DropTable(
                name: "NordpoolPrices");

            migrationBuilder.DropTable(
                name: "ScooterCharges");

            migrationBuilder.DropTable(
                name: "ScooterJourneys");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Scooters");
        }
    }
}
