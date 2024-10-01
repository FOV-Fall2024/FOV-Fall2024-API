using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DishGenerals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

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
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "Price",
                value: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "DishGenerals");

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
                value: new DateTime(2024, 12, 1, 5, 50, 37, 873, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 1, 5, 50, 37, 873, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 1, 5, 50, 37, 873, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 5, 50, 37, 880, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 8, 5, 50, 37, 880, DateTimeKind.Unspecified).AddTicks(7443), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
