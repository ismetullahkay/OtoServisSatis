using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class kasaso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipiId",
                table: "Araclar");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_KasaTipiId",
                table: "Araclar");

            migrationBuilder.RenameColumn(
                name: "KasaTip",
                table: "KasaTipis",
                newName: "KasaTipi");

            migrationBuilder.AddColumn<int>(
                name: "KasaTipisId",
                table: "Araclar",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 17, 17, 37, 10, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KasaTipisId",
                table: "Araclar",
                column: "KasaTipisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar",
                column: "KasaTipisId",
                principalTable: "KasaTipis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar");

            migrationBuilder.DropIndex(
                name: "IX_Araclar_KasaTipisId",
                table: "Araclar");

            migrationBuilder.DropColumn(
                name: "KasaTipisId",
                table: "Araclar");

            migrationBuilder.RenameColumn(
                name: "KasaTipi",
                table: "KasaTipis",
                newName: "KasaTip");

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
    }
}
