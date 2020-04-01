using Microsoft.EntityFrameworkCore.Migrations;

namespace Modernizing.Infrastructure.Persistence.Migrations
{
    public partial class AddingWon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Won",
                table: "Participants",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Won",
                table: "Participants");
        }
    }
}
