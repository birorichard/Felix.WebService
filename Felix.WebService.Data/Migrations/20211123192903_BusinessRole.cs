using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class BusinessRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessRoleId",
                schema: "user",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessRole",
                schema: "business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalCode = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessRoleId",
                schema: "user",
                table: "User",
                column: "BusinessRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_BusinessRole_BusinessRoleId",
                schema: "user",
                table: "User",
                column: "BusinessRoleId",
                principalSchema: "business",
                principalTable: "BusinessRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_BusinessRole_BusinessRoleId",
                schema: "user",
                table: "User");

            migrationBuilder.DropTable(
                name: "BusinessRole",
                schema: "business");

            migrationBuilder.DropIndex(
                name: "IX_User_BusinessRoleId",
                schema: "user",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BusinessRoleId",
                schema: "user",
                table: "User");
        }
    }
}
