using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaApi.Migrations
{
    public partial class addVillaNumToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNO = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNO);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 3, 1, 35, 39, 862, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 3, 1, 35, 39, 862, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 3, 1, 35, 39, 862, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 3, 1, 35, 39, 862, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 10, 3, 1, 35, 39, 862, DateTimeKind.Local).AddTicks(7576));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 2, 44, 17, 67, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 2, 44, 17, 67, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 2, 44, 17, 67, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 2, 44, 17, 67, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 2, 44, 17, 67, DateTimeKind.Local).AddTicks(6483));
        }
    }
}
