using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simulator_Web.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "simulationDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AllPeople = table.Column<int>(type: "INTEGER", nullable: false),
                    AllHealthyPeoples = table.Column<int>(type: "INTEGER", nullable: false),
                    AllInfectedPeoples = table.Column<int>(type: "INTEGER", nullable: false),
                    AllDeadPeoples = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simulationDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "simulationRuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfRun = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simulationRuns", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "simulationDatas");

            migrationBuilder.DropTable(
                name: "simulationRuns");
        }
    }
}
