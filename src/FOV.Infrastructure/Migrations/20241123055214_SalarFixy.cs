using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SalarFixy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalaryId",
                table: "WaiterSchedules",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalaryId",
                table: "WaiterSalary",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalaryType = table.Column<int>(type: "integer", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSalary_SalaryId",
                table: "WaiterSalary",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSalary_Salary_SalaryId",
                table: "WaiterSalary",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Salary_SalaryId",
                table: "WaiterSchedules",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSalary_Salary_SalaryId",
                table: "WaiterSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Salary_SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropIndex(
                name: "IX_WaiterSchedules_SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WaiterSalary_SalaryId",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "WaiterSchedules");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "WaiterSalary");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
    }
}
