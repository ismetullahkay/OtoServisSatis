using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class kazo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar");

            migrationBuilder.AlterColumn<int>(
                name: "KasaTipisId",
                table: "Araclar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 17, 34, 21, 399, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar",
                column: "KasaTipisId",
                principalTable: "KasaTipis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar");

            migrationBuilder.AlterColumn<int>(
                name: "KasaTipisId",
                table: "Araclar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 30, 17, 22, 38, 187, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.AddForeignKey(
                name: "FK_Araclar_KasaTipis_KasaTipisId",
                table: "Araclar",
                column: "KasaTipisId",
                principalTable: "KasaTipis",
                principalColumn: "Id");
        }
    }
}
