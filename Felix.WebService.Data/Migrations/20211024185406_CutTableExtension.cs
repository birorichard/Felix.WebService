using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class CutTableExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "movie",
                table: "Cut",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "movie",
                table: "Cut",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "movie",
                table: "Cut",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "movie",
                table: "Cut");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "movie",
                table: "Cut");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "movie",
                table: "Cut");
        }
    }
}
