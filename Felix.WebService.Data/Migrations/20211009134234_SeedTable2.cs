using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class SeedTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seed",
                schema: "business",
                table: "Seed");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "business",
                table: "Seed",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seed",
                schema: "business",
                table: "Seed",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seed",
                schema: "business",
                table: "Seed");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "business",
                table: "Seed");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seed",
                schema: "business",
                table: "Seed",
                column: "Guid");
        }
    }
}
