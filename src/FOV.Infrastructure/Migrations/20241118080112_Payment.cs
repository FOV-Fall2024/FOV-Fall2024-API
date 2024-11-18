using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FinalAmount",
                table: "Payments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReduceAmount",
                table: "Payments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 18, 8, 1, 11, 215, DateTimeKind.Utc).AddTicks(3200), new DateTime(2024, 11, 18, 8, 1, 11, 215, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 18, 8, 1, 11, 215, DateTimeKind.Utc).AddTicks(3210), new DateTime(2024, 11, 18, 8, 1, 11, 215, DateTimeKind.Utc).AddTicks(3211) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalAmount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReduceAmount",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1359), new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1366), new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1366) });
        }
    }
}
