using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainRefundInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DishIngredientStatus",
                table: "DishIngredients",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefund",
                table: "DishGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "NonPreparedType",
                table: "DishGenerals",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "RefundDishInventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundDishInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundDishInventory_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefundDishInventoryTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RefundDishInventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundDishInventoryTransactionType = table.Column<byte>(type: "smallint", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundDishInventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundDishInventoryTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RefundDishInventoryTransactions_RefundDishInventory_RefundD~",
                        column: x => x.RefundDishInventoryId,
                        principalTable: "RefundDishInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefundDishUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundDishInventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "numeric", nullable: true),
                    RefundDishUnitParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundDishUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundDishUnit_RefundDishInventory_RefundDishInventoryId",
                        column: x => x.RefundDishInventoryId,
                        principalTable: "RefundDishInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefundDishUnit_RefundDishUnit_RefundDishUnitParentId",
                        column: x => x.RefundDishUnitParentId,
                        principalTable: "RefundDishUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 15, 31, 1, 192, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 15, 31, 1, 192, DateTimeKind.Utc).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 4, 15, 31, 1, 192, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                columns: new[] { "IsRefund", "NonPreparedType" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                columns: new[] { "IsRefund", "NonPreparedType" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                columns: new[] { "IsRefund", "NonPreparedType" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                columns: new[] { "IsRefund", "NonPreparedType" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                columns: new[] { "IsRefund", "NonPreparedType" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 15, 31, 1, 204, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 15, 31, 1, 204, DateTimeKind.Unspecified).AddTicks(7382), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishInventory_DishId",
                table: "RefundDishInventory",
                column: "DishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishInventoryTransactions_OrderId",
                table: "RefundDishInventoryTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishInventoryTransactions_RefundDishInventoryId",
                table: "RefundDishInventoryTransactions",
                column: "RefundDishInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishUnit_RefundDishInventoryId",
                table: "RefundDishUnit",
                column: "RefundDishInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishUnit_RefundDishUnitParentId",
                table: "RefundDishUnit",
                column: "RefundDishUnitParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefundDishInventoryTransactions");

            migrationBuilder.DropTable(
                name: "RefundDishUnit");

            migrationBuilder.DropTable(
                name: "RefundDishInventory");

            migrationBuilder.DropColumn(
                name: "DishIngredientStatus",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "IsRefund",
                table: "DishGenerals");

            migrationBuilder.DropColumn(
                name: "NonPreparedType",
                table: "DishGenerals");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 9, 14, 7, 278, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 4, 9, 14, 7, 278, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 4, 9, 14, 7, 278, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 9, 14, 7, 284, DateTimeKind.Unspecified).AddTicks(3973), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 11, 9, 14, 7, 284, DateTimeKind.Unspecified).AddTicks(4014), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
