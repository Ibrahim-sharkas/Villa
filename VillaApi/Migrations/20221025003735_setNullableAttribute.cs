using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaApi.Migrations
{
    public partial class setNullableAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 25, 2, 37, 35, 438, DateTimeKind.Local).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 25, 2, 37, 35, 438, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 25, 2, 37, 35, 438, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 25, 2, 37, 35, 438, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 25, 2, 37, 35, 438, DateTimeKind.Local).AddTicks(5823));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 19, 12, 3, 7, 553, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 19, 12, 3, 7, 553, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 19, 12, 3, 7, 553, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 19, 12, 3, 7, 553, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 19, 12, 3, 7, 553, DateTimeKind.Local).AddTicks(5620));
        }
    }
}
