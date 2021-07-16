using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class added_Round_Number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roundNumber",
                table: "Round",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roundNumber",
                table: "Round");
        }
    }
}
