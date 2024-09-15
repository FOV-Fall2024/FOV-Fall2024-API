using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixWaiterScheduleDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateTime",
                table: "WaiterSchedules",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "WaiterSchedules",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId1",
                table: "WaiterSchedules",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 10, 9, 0, 21, 428, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 10, 9, 0, 21, 428, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 10, 9, 0, 21, 428, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSchedules_EmployeeId1",
                table: "WaiterSchedules",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId1",
                table: "WaiterSchedules",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId1",
                table: "WaiterSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WaiterSchedules_EmployeeId1",
                table: "WaiterSchedules");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "WaiterSchedules");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "WaiterSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "WaiterSchedules",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 7, 2, 53, 33, 355, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 7, 2, 53, 33, 355, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 7, 2, 53, 33, 355, DateTimeKind.Utc).AddTicks(3108));
        }
    }
}
