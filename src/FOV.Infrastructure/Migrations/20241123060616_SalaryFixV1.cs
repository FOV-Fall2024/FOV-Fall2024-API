using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalaryFixV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Salary_SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WaiterSchedules_SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4781), new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4786), new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4786) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalaryId",
                table: "WaiterSchedules",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 5, 52, 13, 802, DateTimeKind.Utc).AddTicks(3481), new DateTime(2024, 11, 23, 5, 52, 13, 802, DateTimeKind.Utc).AddTicks(3484) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 5, 52, 13, 802, DateTimeKind.Utc).AddTicks(3495), new DateTime(2024, 11, 23, 5, 52, 13, 802, DateTimeKind.Utc).AddTicks(3495) });

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSchedules_SalaryId",
                table: "WaiterSchedules",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Salary_SalaryId",
                table: "WaiterSchedules",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id");
        }
    }
}
