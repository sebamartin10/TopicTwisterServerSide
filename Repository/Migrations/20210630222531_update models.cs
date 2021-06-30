using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSession",
                columns: table => new
                {
                    PlayerSessionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSession", x => x.PlayerSessionID);
                    table.ForeignKey(
                        name: "FK_PlayerSession_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerSession_Session_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Session",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    RoundID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LetterID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.RoundID);
                    table.ForeignKey(
                        name: "FK_Round_Letter_LetterID",
                        column: x => x.LetterID,
                        principalTable: "Letter",
                        principalColumn: "LetterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Round_Session_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Session",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turn",
                columns: table => new
                {
                    TurnID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoundID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turn", x => x.TurnID);
                    table.ForeignKey(
                        name: "FK_Turn_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turn_Round_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Round",
                        principalColumn: "RoundID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WordAnswered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WordID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TurnID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Turn_TurnID",
                        column: x => x.TurnID,
                        principalTable: "Turn",
                        principalColumn: "TurnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Word_WordID",
                        column: x => x.WordID,
                        principalTable: "Word",
                        principalColumn: "WordID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_CategoryID",
                table: "Answer",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_TurnID",
                table: "Answer",
                column: "TurnID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_WordID",
                table: "Answer",
                column: "WordID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSession_PlayerID",
                table: "PlayerSession",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSession_SessionID",
                table: "PlayerSession",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Round_LetterID",
                table: "Round",
                column: "LetterID");

            migrationBuilder.CreateIndex(
                name: "IX_Round_SessionID",
                table: "Round",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Turn_PlayerID",
                table: "Turn",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Turn_RoundID",
                table: "Turn",
                column: "RoundID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "PlayerSession");

            migrationBuilder.DropTable(
                name: "Turn");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
