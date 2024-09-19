using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateProductGeneralDomainv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ProductGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 45, 6, 393, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "IsDraft",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "IsDraft",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "IsDraft",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "IsDraft",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "IsDraft",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ProductGenerals");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 5, 14, 11, 241, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 19, 5, 14, 11, 241, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 19, 5, 14, 11, 241, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 14, 11, 242, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 14, 11, 242, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 19, 5, 14, 11, 242, DateTimeKind.Utc).AddTicks(1997));
        }
    }
}
