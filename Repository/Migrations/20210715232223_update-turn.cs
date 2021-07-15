using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class updateturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "correctAnswers",
                table: "Turn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "finishTime",
                table: "Turn",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "finished",
                table: "Turn",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correctAnswers",
                table: "Turn");

            migrationBuilder.DropColumn(
                name: "finishTime",
                table: "Turn");

            migrationBuilder.DropColumn(
                name: "finished",
                table: "Turn");
        }
    }
}
