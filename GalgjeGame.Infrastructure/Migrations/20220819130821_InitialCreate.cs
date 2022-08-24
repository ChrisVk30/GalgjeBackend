using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalgjeGame.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE   PROCEDURE [dbo].[SPC_GetWordToGuess] 
                     -- Add the parameters for the stored procedure here
                     @Value NVARCHAR(100) OUTPUT
                    AS
                    BEGIN
                     -- SET NOCOUNT ON added to prevent extra result sets from
                     -- interfering with SELECT statements.
                     SET NOCOUNT ON;

                    -- Insert statements for procedure here
                     SET @Value = (SELECT TOP 1 Value FROM WordsToBeGuessed
                     ORDER BY NEWID())

                     SELECT @Value AS Value;
                    END
                    GO";

            migrationBuilder.Sql(sp);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "WordsToBeGuessed",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsToBeGuessed", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightLetters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongLetters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeElapsed = table.Column<TimeSpan>(type: "time", nullable: true),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "WordsToBeGuessed");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
