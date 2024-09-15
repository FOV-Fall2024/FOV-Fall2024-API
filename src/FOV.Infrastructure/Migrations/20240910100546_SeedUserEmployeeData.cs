using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2024, 11, 10, 10, 5, 46, 352, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 10, 10, 5, 46, 352, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 10, 10, 5, 46, 352, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "CreatedBy", "EmployeeCode", "HireDate", "IsDeleted", "LastModified", "LastModifiedBy", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"), new DateTimeOffset(new DateTime(2022, 5, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "manager", "EMP002", new DateTime(2024, 9, 10, 10, 5, 46, 353, DateTimeKind.Utc).AddTicks(1739), false, new DateTimeOffset(new DateTime(2022, 5, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "manager", new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), "f5404c4e-88b5-428e-8b07-b44af0d35979" },
                    { new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"), new DateTimeOffset(new DateTime(2022, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin", "EMP001", new DateTime(2024, 9, 10, 10, 5, 46, 353, DateTimeKind.Utc).AddTicks(1621), false, new DateTimeOffset(new DateTime(2022, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin", new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), "6fb87153-242c-4024-a3af-f787b3919760" },
                    { new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"), new DateTimeOffset(new DateTime(2023, 3, 20, 14, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin", "EMP003", new DateTime(2024, 9, 10, 10, 5, 46, 353, DateTimeKind.Utc).AddTicks(1749), false, new DateTimeOffset(new DateTime(2023, 3, 20, 14, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "admin", new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), "5680415f-f3b6-4288-899f-c01a357f150f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"));

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
        }
    }
}
