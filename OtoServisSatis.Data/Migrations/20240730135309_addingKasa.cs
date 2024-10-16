using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingKasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KasaTipis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaTip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasaTipis", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "KasaTipis",
                columns: new[] { "Id", "KasaTip" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "HatchBack" },
                    { 3, "SUV" },
                    { 4, "Pick-Up" },
                    { 5, "Station" }
                });

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 16, 53, 9, 880, DateTimeKind.Local).AddTicks(2236));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KasaTipis");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 16, 46, 55, 132, DateTimeKind.Local).AddTicks(5110));
        }
    }
}
