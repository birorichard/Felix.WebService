using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class MovieUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                schema: "movie",
                table: "Movie",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "movie",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie",
                column: "CodeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "movie",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "CodeName",
                schema: "movie",
                table: "Movie",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie",
                column: "CodeName",
                unique: true,
                filter: "[CodeName] IS NOT NULL");
        }
    }
}
