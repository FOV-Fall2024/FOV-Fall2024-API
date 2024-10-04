using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 6, 9, 9, 889, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 6, 9, 9, 889, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 4, 6, 9, 9, 889, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 6, 9, 9, 895, DateTimeKind.Unspecified).AddTicks(5592), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 6, 9, 9, 895, DateTimeKind.Unspecified).AddTicks(5621), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 4, 52, 42, 624, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 4, 52, 42, 624, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 4, 4, 52, 42, 624, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientMeasure",
                value: (byte)255);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 4, 52, 42, 629, DateTimeKind.Unspecified).AddTicks(1504), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 4, 52, 42, 629, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
