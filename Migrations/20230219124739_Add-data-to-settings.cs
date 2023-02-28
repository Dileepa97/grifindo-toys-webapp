using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class Adddatatosettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Settings ([option], value) VALUES ('Salary Cycle Date Range', '30'),('Salary Cycle Start Date', '2023-01-01'),('Salary Cycle End Date', '2023-01-30'),('Allocated leaves', '30')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
