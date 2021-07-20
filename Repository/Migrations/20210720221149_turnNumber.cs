using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class turnNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "turnNumber",
                table: "Turn",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "turnNumber",
                table: "Turn");
        }
    }
}
