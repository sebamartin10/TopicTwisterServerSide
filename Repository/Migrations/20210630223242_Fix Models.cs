using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class FixModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoundCategory",
                columns: table => new
                {
                    RoundCategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoundID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundCategory", x => x.RoundCategoryID);
                    table.ForeignKey(
                        name: "FK_RoundCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundCategory_Round_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Round",
                        principalColumn: "RoundID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WordCategory",
                columns: table => new
                {
                    WordCategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WordID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCategory", x => x.WordCategoryID);
                    table.ForeignKey(
                        name: "FK_WordCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordCategory_Word_WordID",
                        column: x => x.WordID,
                        principalTable: "Word",
                        principalColumn: "WordID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundCategory_CategoryID",
                table: "RoundCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundCategory_RoundID",
                table: "RoundCategory",
                column: "RoundID");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategory_CategoryID",
                table: "WordCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategory_WordID",
                table: "WordCategory",
                column: "WordID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundCategory");

            migrationBuilder.DropTable(
                name: "WordCategory");
        }
    }
}
