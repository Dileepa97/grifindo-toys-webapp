using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class addtaxratetosettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Settings ([option], value) VALUES ('Government Tax Rate', '0.1')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
