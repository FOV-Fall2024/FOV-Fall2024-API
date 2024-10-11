using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ComboAdjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "DishImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishGenerals");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Combos");

            migrationBuilder.AddColumn<string>(
                name: "DishMainImage",
                table: "Dishes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "DishMainImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "DishMainImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "DishMainImage",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishMainImage",
                table: "Dishes");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "DishImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Combos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Combos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                columns: new[] { "ExpiredDate", "Quantity" },
                values: new object[] { new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), 10 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                columns: new[] { "ExpiredDate", "Quantity" },
                values: new object[] { new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), 10 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                columns: new[] { "ExpiredDate", "Quantity" },
                values: new object[] { new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), 20 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "IsDeleted",
                value: false);
        }
    }
}
