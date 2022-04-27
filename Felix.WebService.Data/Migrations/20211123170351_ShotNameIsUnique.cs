using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class ShotNameIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "movie",
                table: "Shot",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shot_Name",
                schema: "movie",
                table: "Shot",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shot_Name",
                schema: "movie",
                table: "Shot");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "movie",
                table: "Shot",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
