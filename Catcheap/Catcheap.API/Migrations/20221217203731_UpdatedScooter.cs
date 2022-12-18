using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catcheap.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedScooter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageSpeed",
                table: "Scooters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageSpeed",
                table: "Scooters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
