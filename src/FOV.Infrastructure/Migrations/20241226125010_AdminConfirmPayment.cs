using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminConfirmPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WaiterSalary");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateTime",
                table: "WaiterSchedules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminConfirm",
                table: "Payments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 12, 50, 9, 444, DateTimeKind.Utc).AddTicks(767), new DateTime(2024, 12, 26, 12, 50, 9, 444, DateTimeKind.Utc).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 12, 50, 9, 444, DateTimeKind.Utc).AddTicks(780), new DateTime(2024, 12, 26, 12, 50, 9, 444, DateTimeKind.Utc).AddTicks(781) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminConfirm",
                table: "Payments");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateTime",
                table: "WaiterSchedules",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WaiterSalary",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 4, 14, 18, 9, 295, DateTimeKind.Utc).AddTicks(6410), new DateTime(2024, 12, 4, 14, 18, 9, 295, DateTimeKind.Utc).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 4, 14, 18, 9, 295, DateTimeKind.Utc).AddTicks(6421), new DateTime(2024, 12, 4, 14, 18, 9, 295, DateTimeKind.Utc).AddTicks(6421) });
        }
    }
}
