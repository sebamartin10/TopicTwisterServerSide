using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class added_Session_Result : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionResult",
                columns: table => new
                {
                    SessionResultID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusPlayer = table.Column<int>(type: "int", nullable: false),
                    SessionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionResult", x => x.SessionResultID);
                    table.ForeignKey(
                        name: "FK_SessionResult_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionResult_Session_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Session",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionResult_PlayerID",
                table: "SessionResult",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionResult_SessionID",
                table: "SessionResult",
                column: "SessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionResult");
        }
    }
}
