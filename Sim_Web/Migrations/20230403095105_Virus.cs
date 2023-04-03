using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sim_Web.Migrations
{
    public partial class Virus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirusData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProbabilityToDead = table.Column<double>(type: "REAL", nullable: false),
                    IncubationTime = table.Column<double>(type: "REAL", nullable: false),
                    InfectionSeverity = table.Column<double>(type: "REAL", nullable: false),
                    ProbabilityToCure = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirusData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirusData");
        }
    }
}
