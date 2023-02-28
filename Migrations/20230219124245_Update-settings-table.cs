using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrifindoToys.Migrations
{
    public partial class Updatesettingstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllocatedLeaves",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SalaryCycleBeginDate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SalaryCycleDateRange",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SalaryCycleEndDate",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "option",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "option",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "value",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "AllocatedLeaves",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalaryCycleBeginDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SalaryCycleDateRange",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalaryCycleEndDate",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
