using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class Upadtedemployeemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Allowanaces",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthlySalary",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "OTPerHour",
                table: "Employee",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowanaces",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OTPerHour",
                table: "Employee");
        }
    }
}
