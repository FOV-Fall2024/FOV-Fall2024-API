using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WaiterSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualHoursWorked",
                table: "WaiterSalary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OvertimeSalary",
                table: "WaiterSalary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Penalty",
                table: "WaiterSalary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularSalary",
                table: "WaiterSalary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalHoursWorked",
                table: "WaiterSalary",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderResponsibility",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility");

            migrationBuilder.DropColumn(
                name: "ActualHoursWorked",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "OvertimeSalary",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "RegularSalary",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "TotalHoursWorked",
                table: "WaiterSalary");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderResponsibility",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 2, 9, 29, 44, 101, DateTimeKind.Utc).AddTicks(9208), new DateTime(2024, 12, 2, 9, 29, 44, 101, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 2, 9, 29, 44, 101, DateTimeKind.Utc).AddTicks(9218), new DateTime(2024, 12, 2, 9, 29, 44, 101, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
