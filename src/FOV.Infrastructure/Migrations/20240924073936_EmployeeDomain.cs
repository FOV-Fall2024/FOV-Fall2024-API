using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5680415f-f3b6-4288-899f-c01a357f150f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fb87153-242c-4024-a3af-f787b3919760");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5404c4e-88b5-428e-8b07-b44af0d35979");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "WaiterSchedules",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Employees",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                columns: new[] { "HireDate", "Status" },
                values: new object[] { new DateTime(2024, 9, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(5146), (byte)1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                columns: new[] { "HireDate", "Status" },
                values: new object[] { new DateTime(2024, 9, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(4881), (byte)1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                columns: new[] { "HireDate", "Status" },
                values: new object[] { new DateTime(2024, 9, 24, 7, 39, 35, 560, DateTimeKind.Utc).AddTicks(5158), (byte)1 });

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "WaiterSchedules",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5680415f-f3b6-4288-899f-c01a357f150f", 0, "C3D4E5F6G7H8", "alicej@example.com", true, "Alice", "Johnson", true, null, "ALICEJ@EXAMPLE.COM", "ALICEJ", "AQAAAAEAACcQAAAAEJ8s5t7kDv3X8bJ9fTS6nMk1h8jsnklRQNkqpL0z7oK45kM1WfqvQ9F9F8yPdMcbw==", "1122334455", true, "C3D4E5F6G7", false, "alicej" },
                    { "6fb87153-242c-4024-a3af-f787b3919760", 0, "A1B2C3D4E5F6", "nguyenanh@gmail.com", true, "Nguyen", "Anh", true, null, "NGUYENANH@GMAIL.COM", "NGUYENANH", "AQAAAAEAACcQAAAAEP9r4v1tjDThjF1X2Rj3QvB1MzQaXJkblzP1LkL0fMPOZ5WsmXAf3P9N2WkPdMbxpg==", "1234567890", true, "A1B2C3D4E5", false, "NguyenAnh" },
                    { "f5404c4e-88b5-428e-8b07-b44af0d35979", 0, "B2C3D4E5F6G7", "huynhanh@gmail.com", true, "Huynh", "Anh", true, null, "HUYNHANH@GMAIL.COM", "HUYNHANH", "AQAAAAEAACcQAAAAEHyv3s9XjAzOiDvB9vFS5Mkj8g7vnklQJkwpjCZr4mK34eM1JwqvP9M8F7wPdNBcy==", "0987654321", true, "B2C3D4E5F6", false, "HuynhAnh" }
                });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 20, 8, 54, 4, 224, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
