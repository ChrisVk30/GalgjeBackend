using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalgjeGame.Migrations
{
    public partial class SplitUserClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "IncorrectGuesses",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeElapsedInGuessing",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimesPlayed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WordsGuessed",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "WordsToBeGuessed");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "UserGameID",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserScoreID",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordsToBeGuessed",
                table: "WordsToBeGuessed",
                column: "Word");

            migrationBuilder.CreateTable(
                name: "UserGameScores",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeElapsedInGuessing = table.Column<int>(type: "int", nullable: false),
                    IncorrectGuesses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameScores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserOverallScores",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordsGuessed = table.Column<int>(type: "int", nullable: false),
                    TimesPlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOverallScores", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGameID",
                table: "Users",
                column: "UserGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserScoreID",
                table: "Users",
                column: "UserScoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserGameScores_UserGameID",
                table: "Users",
                column: "UserGameID",
                principalTable: "UserGameScores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserOverallScores_UserScoreID",
                table: "Users",
                column: "UserScoreID",
                principalTable: "UserOverallScores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserGameScores_UserGameID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserOverallScores_UserScoreID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserGameScores");

            migrationBuilder.DropTable(
                name: "UserOverallScores");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserGameID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserScoreID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordsToBeGuessed",
                table: "WordsToBeGuessed");

            migrationBuilder.DropColumn(
                name: "UserGameID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserScoreID",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "WordsToBeGuessed",
                newName: "Words");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<int>(
                name: "IncorrectGuesses",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeElapsedInGuessing",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesPlayed",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WordsGuessed",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Word");
        }
    }
}
