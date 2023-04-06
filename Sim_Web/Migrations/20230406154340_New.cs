using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sim_Web.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RectanglePointers",
                table: "simulationRuns",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RectanglePointers",
                table: "simulationRuns");
        }
    }
}
