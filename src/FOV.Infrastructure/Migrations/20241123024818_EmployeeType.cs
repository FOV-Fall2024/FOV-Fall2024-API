using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeType",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 2, 48, 17, 165, DateTimeKind.Utc).AddTicks(7891), new DateTime(2024, 11, 23, 2, 48, 17, 165, DateTimeKind.Utc).AddTicks(7891) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 2, 48, 17, 165, DateTimeKind.Utc).AddTicks(7903), new DateTime(2024, 11, 23, 2, 48, 17, 165, DateTimeKind.Utc).AddTicks(7903) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "AspNetUsers");

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
    }
}
