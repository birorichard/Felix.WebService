using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class ShotUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "movie",
                table: "Shot",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "movie",
                table: "Shot");
        }
    }
}
