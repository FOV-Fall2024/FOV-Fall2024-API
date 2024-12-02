using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility");

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
                values: new object[] { new DateTime(2024, 12, 2, 7, 56, 25, 202, DateTimeKind.Utc).AddTicks(7913), new DateTime(2024, 12, 2, 7, 56, 25, 202, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 2, 7, 56, 25, 202, DateTimeKind.Utc).AddTicks(7920), new DateTime(2024, 12, 2, 7, 56, 25, 202, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderResponsibility_Orders_OrderId",
                table: "OrderResponsibility",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
