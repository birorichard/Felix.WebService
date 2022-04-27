using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class ShotUniqueConstraintUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shot_Name",
                schema: "movie",
                table: "Shot");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "movie",
                table: "Shot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shot_Name_Version",
                schema: "movie",
                table: "Shot",
                columns: new[] { "Name", "Version" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shot_Name_Version",
                schema: "movie",
                table: "Shot");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "movie",
                table: "Shot");

            migrationBuilder.CreateIndex(
                name: "IX_Shot_Name",
                schema: "movie",
                table: "Shot",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
