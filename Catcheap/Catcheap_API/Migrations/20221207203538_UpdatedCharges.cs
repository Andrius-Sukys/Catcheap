using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatcheapAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCharges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ChargingPrice",
                table: "ScooterCharges",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ChargingPrice",
                table: "CarCharges",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargingPrice",
                table: "ScooterCharges");

            migrationBuilder.DropColumn(
                name: "ChargingPrice",
                table: "CarCharges");
        }
    }
}
