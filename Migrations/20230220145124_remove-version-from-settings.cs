using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class removeversionfromsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Settings",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
