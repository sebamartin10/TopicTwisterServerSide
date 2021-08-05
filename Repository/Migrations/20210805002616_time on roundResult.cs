using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class timeonroundResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Time",
                table: "RoundResult",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "RoundResult");
        }
    }
}
