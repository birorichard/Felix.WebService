using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class CommentUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_CreatedById",
                schema: "comment",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                schema: "comment",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_CreatedById",
                schema: "comment",
                table: "Comment",
                column: "CreatedById",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_CreatedById",
                schema: "comment",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                schema: "comment",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_CreatedById",
                schema: "comment",
                table: "Comment",
                column: "CreatedById",
                principalSchema: "user",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
