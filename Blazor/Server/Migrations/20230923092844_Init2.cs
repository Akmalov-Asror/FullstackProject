using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Test",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Test_LessonId",
                table: "Test",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Lesson_LessonId",
                table: "Test",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Lesson_LessonId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_LessonId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Test");
        }
    }
}
