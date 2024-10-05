using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainRefundInventorV36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PercentagePriceDifference",
                table: "DishGenerals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 5, 9, 57, 10, 553, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 5, 9, 57, 10, 553, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 9, 57, 10, 553, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "PercentagePriceDifference",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "PercentagePriceDifference",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "PercentagePriceDifference",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "PercentagePriceDifference",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "PercentagePriceDifference",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                columns: new[] { "Created", "ReleaseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 5, 16, 57, 10, 561, DateTimeKind.Unspecified).AddTicks(2931), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 10, 12, 9, 57, 10, 561, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                columns: new[] { "Created", "ReleaseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 5, 16, 57, 10, 561, DateTimeKind.Unspecified).AddTicks(2949), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 10, 12, 9, 57, 10, 561, DateTimeKind.Unspecified).AddTicks(2947), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentagePriceDifference",
                table: "DishGenerals");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 5, 9, 25, 28, 578, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 5, 9, 25, 28, 578, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 9, 25, 28, 578, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                columns: new[] { "Created", "ReleaseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 5, 16, 25, 28, 587, DateTimeKind.Unspecified).AddTicks(8215), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 10, 12, 9, 25, 28, 587, DateTimeKind.Unspecified).AddTicks(8189), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                columns: new[] { "Created", "ReleaseDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 10, 5, 16, 25, 28, 587, DateTimeKind.Unspecified).AddTicks(8236), new TimeSpan(0, 7, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 10, 12, 9, 25, 28, 587, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
