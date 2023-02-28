using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class Salarymodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    CycleStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CycleEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbsentDays = table.Column<int>(type: "int", nullable: false),
                    OTHours = table.Column<int>(type: "int", nullable: false),
                    NoPayValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasePayValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPayValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => new { x.Id, x.EmpId, x.CycleStartDate, x.CycleEndDate });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salary");
        }
    }
}
