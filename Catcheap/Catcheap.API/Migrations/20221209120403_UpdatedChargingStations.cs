using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catcheap.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedChargingStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ChargingStations",
                newName: "Street");

            migrationBuilder.AddColumn<short>(
                name: "StreetNumber",
                table: "ChargingStations",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "ChargingStations");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "ChargingStations",
                newName: "Address");
        }
    }
}