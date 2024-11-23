using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSalary",
                table: "WaiterSalary",
                newName: "TotalShifts");

            migrationBuilder.RenameColumn(
                name: "TotalHours",
                table: "WaiterSalary",
                newName: "TotalSalaries");

            migrationBuilder.AddColumn<decimal>(
                name: "RoleSalary",
                table: "AspNetRoles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 4, 1, 31, 765, DateTimeKind.Utc).AddTicks(6973), new DateTime(2024, 11, 23, 4, 1, 31, 765, DateTimeKind.Utc).AddTicks(6974) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 4, 1, 31, 765, DateTimeKind.Utc).AddTicks(6982), new DateTime(2024, 11, 23, 4, 1, 31, 765, DateTimeKind.Utc).AddTicks(6982) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleSalary",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "TotalShifts",
                table: "WaiterSalary",
                newName: "TotalSalary");

            migrationBuilder.RenameColumn(
                name: "TotalSalaries",
                table: "WaiterSalary",
                newName: "TotalHours");

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
    }
}
