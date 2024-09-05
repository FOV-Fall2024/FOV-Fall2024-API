using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Payments");

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboName", "Created", "CreatedBy", "ExpiredDate", "IsDeleted", "LastModified", "LastModifiedBy", "PercentReduce", "Price", "Quantity", "RestaurantId", "Status" },
                values: new object[] { new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"), "Combo 1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTime(2024, 10, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2766), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 10.0m, 50.00m, 20, new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"), (byte)0 });

            migrationBuilder.InsertData(
                table: "ProductGenerals",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Lẩu chay ngon", "Vegan Hotpot" },
                    { new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Cơm ngon", "Cơm trắng" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "RestataurantCode", "RestaurantName", "RestaurantPhone", "Status" },
                values: new object[] { new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), "Thu Duc", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "RE_002", "Vege Thu Duc", "0867960120", (byte)0 });

            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboName", "Created", "CreatedBy", "ExpiredDate", "IsDeleted", "LastModified", "LastModifiedBy", "PercentReduce", "Price", "Quantity", "RestaurantId", "Status" },
                values: new object[,]
                {
                    { new Guid("3907a193-c2ae-4f40-936b-9a2438595123"), "Combo 2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTime(2024, 11, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2779), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5.0m, 30.00m, 10, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)0 },
                    { new Guid("921b269a-db6e-4a1d-b285-70df523e010e"), "Combo 3", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTime(2024, 11, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2782), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5.0m, 30.00m, 10, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Price", "ProductDescription", "ProductGeneralId", "ProductName", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0m, "Description", new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"), "Cơm Không", new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007") },
                    { new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"), new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 0m, "Siêu rẻ", new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"), "Lẩu chay Thủ Đức", new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"));

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"));

            migrationBuilder.DeleteData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"));

            migrationBuilder.DeleteData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"));

            migrationBuilder.DeleteData(
                table: "ProductGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"));

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
