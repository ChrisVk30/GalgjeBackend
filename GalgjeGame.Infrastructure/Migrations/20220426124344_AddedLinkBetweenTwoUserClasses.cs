using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalgjeGame.Migrations
{
    public partial class AddedLinkBetweenTwoUserClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOverallScores",
                table: "UserOverallScores");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UserOverallScores");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserOverallScores",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserGameScores",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOverallScores",
                table: "UserOverallScores",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameScores_UserName",
                table: "UserGameScores",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameScores_UserOverallScores_UserName",
                table: "UserGameScores",
                column: "UserName",
                principalTable: "UserOverallScores",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameScores_UserOverallScores_UserName",
                table: "UserGameScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOverallScores",
                table: "UserOverallScores");

            migrationBuilder.DropIndex(
                name: "IX_UserGameScores_UserName",
                table: "UserGameScores");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserOverallScores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "UserOverallScores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserGameScores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOverallScores",
                table: "UserOverallScores",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGameID = table.Column<long>(type: "bigint", nullable: false),
                    UserScoreID = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserGameScores_UserGameID",
                        column: x => x.UserGameID,
                        principalTable: "UserGameScores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserOverallScores_UserScoreID",
                        column: x => x.UserScoreID,
                        principalTable: "UserOverallScores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGameID",
                table: "Users",
                column: "UserGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserScoreID",
                table: "Users",
                column: "UserScoreID");
        }
    }
}
