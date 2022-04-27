using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class CommentUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Cut_CutId",
                schema: "comment",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "CutId",
                schema: "comment",
                table: "Comment",
                newName: "ShotCutRelId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_CutId",
                schema: "comment",
                table: "Comment",
                newName: "IX_Comment_ShotCutRelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ShotCutRel_ShotCutRelId",
                schema: "comment",
                table: "Comment",
                column: "ShotCutRelId",
                principalSchema: "movie",
                principalTable: "ShotCutRel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ShotCutRel_ShotCutRelId",
                schema: "comment",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ShotCutRelId",
                schema: "comment",
                table: "Comment",
                newName: "CutId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ShotCutRelId",
                schema: "comment",
                table: "Comment",
                newName: "IX_Comment_CutId");

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
    }
}
