using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class CommentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CutId",
                schema: "comment",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CutId",
                schema: "comment",
                table: "Comment",
                column: "CutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Cut_CutId",
                schema: "comment",
                table: "Comment",
                column: "CutId",
                principalSchema: "movie",
                principalTable: "Cut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Cut_CutId",
                schema: "comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CutId",
                schema: "comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CutId",
                schema: "comment",
                table: "Comment");
        }
    }
}
