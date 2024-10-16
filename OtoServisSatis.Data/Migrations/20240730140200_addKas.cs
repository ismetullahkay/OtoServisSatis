using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class addKas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KasaTipi",
                table: "Araclar");

            migrationBuilder.AddColumn<int>(
                name: "KasaTipiId",
                table: "Araclar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 17, 2, 0, 832, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KasaTipiId",
                table: "Araclar",
                column: "KasaTipiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipiId",
                table: "Araclar",
                column: "KasaTipiId",
                principalTable: "KasaTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipiId",
                table: "Araclar");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_KasaTipiId",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "KasaTipiId",
                table: "Araclar");

            migrationBuilder.AddColumn<string>(
                name: "KasaTipi",
                table: "Araclar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 16, 53, 9, 880, DateTimeKind.Local).AddTicks(2236));
        }
    }
}
