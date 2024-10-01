using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "numeric",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 1, 10, 39, 37, 434, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 1, 10, 39, 37, 434, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 1, 10, 39, 37, 434, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 10, 39, 37, 439, DateTimeKind.Unspecified).AddTicks(5347), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 10, 39, 37, 439, DateTimeKind.Unspecified).AddTicks(5383), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 1, 10, 34, 5, 217, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 1, 10, 34, 5, 217, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 1, 10, 34, 5, 217, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 10, 34, 5, 222, DateTimeKind.Unspecified).AddTicks(6573), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 10, 34, 5, 222, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
