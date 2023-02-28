using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class Upadtedemployeeallowances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Allowanaces",
                table: "Employee",
                newName: "Allowances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Allowances",
                table: "Employee",
                newName: "Allowanaces");
        }
    }
}
