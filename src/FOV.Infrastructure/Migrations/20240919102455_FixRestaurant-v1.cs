using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRestaurantv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 10, 24, 54, 593, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 10, 24, 54, 593, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 19, 10, 24, 54, 593, DateTimeKind.Utc).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 24, 54, 594, DateTimeKind.Utc).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 24, 54, 594, DateTimeKind.Utc).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 24, 54, 594, DateTimeKind.Utc).AddTicks(949));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 10, 0, 26, 264, DateTimeKind.Utc).AddTicks(7171));
        }
    }
}
