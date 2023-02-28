using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "transaсtions",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "transaсtions",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_transaсtions_StudentId",
                table: "transaсtions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_transaсtions_students_StudentId",
                table: "transaсtions",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaсtions_students_StudentId",
                table: "transaсtions");

            migrationBuilder.DropIndex(
                name: "IX_transaсtions_StudentId",
                table: "transaсtions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "transaсtions");
        }
    }
}
