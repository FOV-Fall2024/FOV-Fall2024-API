using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnit_IngredientUnit_IngredientUnitParentId",
                table: "IngredientUnit");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientUnitParentId",
                table: "IngredientUnit",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<byte>(
                name: "IngredientMeasure",
                table: "IngredientGenerals",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 17, 5, 11, 55, 142, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 17, 5, 11, 55, 142, DateTimeKind.Utc).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 17, 5, 11, 55, 142, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 17, 5, 11, 55, 143, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 17, 5, 11, 55, 143, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 17, 5, 11, 55, 143, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a0"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnit_IngredientUnit_IngredientUnitParentId",
                table: "IngredientUnit",
                column: "IngredientUnitParentId",
                principalTable: "IngredientUnit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnit_IngredientUnit_IngredientUnitParentId",
                table: "IngredientUnit");

            migrationBuilder.DropColumn(
                name: "IngredientMeasure",
                table: "IngredientGenerals");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientUnitParentId",
                table: "IngredientUnit",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 16, 10, 37, 13, 515, DateTimeKind.Utc).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 16, 10, 37, 13, 515, DateTimeKind.Utc).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 16, 10, 37, 13, 515, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 10, 37, 13, 516, DateTimeKind.Utc).AddTicks(1284));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 10, 37, 13, 516, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 10, 37, 13, 516, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnit_IngredientUnit_IngredientUnitParentId",
                table: "IngredientUnit",
                column: "IngredientUnitParentId",
                principalTable: "IngredientUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
