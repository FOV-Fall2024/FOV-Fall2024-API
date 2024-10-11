using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedDishWithoutImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"));

            migrationBuilder.DeleteData(
                table: "DishIngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"));

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"));

            migrationBuilder.DeleteData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"));

            migrationBuilder.DeleteData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"));

            migrationBuilder.DeleteData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"));

            migrationBuilder.DeleteData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"));

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "DishImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishGenerals");

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"),
                column: "IngredientName",
                value: "Nguyên liệt ngắn hạn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "DishImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DishGenerals",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "DishDescription", "DishImageDefault", "DishName", "IsDeleted", "IsDraft", "IsRefund", "LastModified", "LastModifiedBy", "PercentagePriceDifference", "Price", "Status" },
                values: new object[,]
                {
                    { new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Lẩu chay ngon", "", "Vegan Hotpot", false, false, true, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20m, 30m, (byte)1 },
                    { new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"), new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Coca-Cola ngon ", "", "Coca-Cola", false, false, true, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20m, 30m, (byte)1 },
                    { new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"), new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "7up ngon ", "", "7up", false, false, true, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20m, 30m, (byte)1 },
                    { new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, " Caprese Salad ngon ", "", " Caprese Salad", false, false, false, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20m, 30m, (byte)1 },
                    { new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Cơm ngon", "", "Cơm trắng", false, false, true, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20m, 30m, (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"),
                column: "IngredientName",
                value: "Short Storage Ingredients");

            migrationBuilder.InsertData(
                table: "DishIngredientGenerals",
                columns: new[] { "Id", "Created", "CreatedBy", "DishGeneralId", "IngredientGeneralId", "LastModified", "LastModifiedBy", "Quantity", "Status" },
                values: new object[] { new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"), new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 2m, (byte)1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "DishDescription", "DishGeneralId", "DishName", "DishType", "LastModified", "LastModifiedBy", "Price", "PriorityDish", "RestaurantId", "Status" },
                values: new object[,]
                {
                    { new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Description", new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"), "Cơm Không", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 20000m, (byte)0, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)0 },
                    { new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"), new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Description", new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"), "7up", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 10000m, (byte)0, new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"), (byte)0 },
                    { new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "Siêu rẻ", new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"), "Lẩu chay Thủ Đức", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 60000m, (byte)0, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)0 }
                });
        }
    }
}
