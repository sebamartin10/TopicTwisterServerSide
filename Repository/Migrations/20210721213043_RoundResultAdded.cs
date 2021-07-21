using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class RoundResultAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoundResult",
                columns: table => new
                {
                    RoundResultID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusPlayer = table.Column<int>(type: "int", nullable: false),
                    RoundID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CorrectWords = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundResult", x => x.RoundResultID);
                    table.ForeignKey(
                        name: "FK_RoundResult_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundResult_Round_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Round",
                        principalColumn: "RoundID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundResult_PlayerID",
                table: "RoundResult",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundResult_RoundID",
                table: "RoundResult",
                column: "RoundID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundResult");
        }
    }
}
