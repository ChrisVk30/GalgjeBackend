using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalgjeGame.Migrations
{
    public partial class AddedTimeFieldsToGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFinished",
                table: "Games",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStarted",
                table: "Games",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeFinished",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TimeStarted",
                table: "Games");
        }
    }
}
