using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sim_Web.Migrations
{
    public partial class NewVirus3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RectanglesWithPeople",
                table: "simulationRuns",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RectanglesWithPeople",
                table: "simulationRuns");
        }
    }
}
