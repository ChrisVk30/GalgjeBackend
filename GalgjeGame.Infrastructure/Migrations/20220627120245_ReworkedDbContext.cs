using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalgjeGame.Migrations
{
    public partial class ReworkedDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "Id");
        }
    }
}
