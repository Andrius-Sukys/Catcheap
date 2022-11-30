using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatcheapAPI.Migrations
{
    public partial class JourneyToDateOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>("Date", "Journey", type: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
