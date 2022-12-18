using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catcheap.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numberplate",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numberplate",
                table: "Cars");
        }
    }
}
