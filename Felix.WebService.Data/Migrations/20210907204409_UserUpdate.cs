using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashAlgorythm",
                schema: "user",
                table: "User",
                newName: "Salt");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "user",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "user",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Salt",
                schema: "user",
                table: "User",
                newName: "HashAlgorythm");
        }
    }
}
