using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Felix.WebService.Data.Migrations
{
    public partial class AddBusinessTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "comment");

            migrationBuilder.EnsureSchema(
                name: "movie");

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartFrame = table.Column<int>(type: "int", nullable: false),
                    EndFrame = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "user",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shot",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartFrame = table.Column<int>(type: "int", nullable: false),
                    EndFrame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cut",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cut_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShotCutRel",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CutId = table.Column<int>(type: "int", nullable: false),
                    ShotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotCutRel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotCutRel_Cut_CutId",
                        column: x => x.CutId,
                        principalSchema: "movie",
                        principalTable: "Cut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShotCutRel_Shot_ShotId",
                        column: x => x.ShotId,
                        principalSchema: "movie",
                        principalTable: "Shot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatedById",
                schema: "comment",
                table: "Comment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cut_MovieId",
                schema: "movie",
                table: "Cut",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotCutRel_CutId",
                schema: "movie",
                table: "ShotCutRel",
                column: "CutId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotCutRel_ShotId",
                schema: "movie",
                table: "ShotCutRel",
                column: "ShotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "comment");

            migrationBuilder.DropTable(
                name: "ShotCutRel",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Cut",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Shot",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "movie");
        }
    }
}
