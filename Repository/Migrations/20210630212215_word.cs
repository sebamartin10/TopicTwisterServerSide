using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class word : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    WordID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WordName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.WordID);
                    table.ForeignKey(
                        name: "FK_Word_Letter_LetterID",
                        column: x => x.LetterID,
                        principalTable: "Letter",
                        principalColumn: "LetterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Word_LetterID",
                table: "Word",
                column: "LetterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}
