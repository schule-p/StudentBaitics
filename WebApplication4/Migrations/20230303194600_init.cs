using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    StudentName = table.Column<string>(type: "text", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    LastDateUpdatePoints = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaсtions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    TypeOfTransaction = table.Column<bool>(type: "boolean", nullable: false),
                    DateTransartion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdStudent = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: true),
                    IdProducts = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaсtions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transaсtions_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transaсtions_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "ProductCount", "ProductName" },
                values: new object[] { 1, 19, "Худи" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "LastDateUpdatePoints", "Points", "StudentName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "Виктор Корнеплод" });

            migrationBuilder.InsertData(
                table: "transaсtions",
                columns: new[] { "Id", "DateTransartion", "IdProducts", "IdStudent", "ProductId", "StudentId", "Sum", "TypeOfTransaction" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, null, 100, false });

            migrationBuilder.CreateIndex(
                name: "IX_transaсtions_ProductId",
                table: "transaсtions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_transaсtions_StudentId",
                table: "transaсtions",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaсtions");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
