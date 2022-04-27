using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class MovieUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                schema: "movie",
                table: "Movie",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie",
                column: "CodeName",
                unique: true,
                filter: "[CodeName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movie_CodeName",
                schema: "movie",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CodeName",
                schema: "movie",
                table: "Movie");
        }
    }
}
