using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainV12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a38cc2f-42d3-454f-80e4-c057e24af1b3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a74dffb1-2ac8-455c-92b4-3980c52e13d0"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("6418ce5b-a4b7-4cf3-9d96-7081282c24a7"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("8b2a5b54-dd87-49f7-af52-db6fcc973db6"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryMain", "CategoryName", "CategoryParentId", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Left", "Right" },
                values: new object[,]
                {
                    { new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"), "Salad", "Salad", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 2 },
                    { new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"), "Noodle", "Noodle", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "ExpiredTime", "IngredientDescription", "IngredientMain", "IngredientName", "IsDeleted", "LastModified", "LastModifiedBy", "Left", "ParentId", "Right" },
                values: new object[,]
                {
                    { new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 30, "", "Processed", "Processed Ingredient", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, null, 2 },
                    { new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 60, "", "Packaged", "Packaged Ingredient", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, null, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryMain", "CategoryName", "CategoryParentId", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Left", "Right" },
                values: new object[,]
                {
                    { new Guid("0a38cc2f-42d3-454f-80e4-c057e24af1b3"), "Salad", "Salad", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 2 },
                    { new Guid("a74dffb1-2ac8-455c-92b4-3980c52e13d0"), "Noodle", "Noodle", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "ExpiredTime", "IngredientDescription", "IngredientMain", "IngredientName", "IsDeleted", "LastModified", "LastModifiedBy", "Left", "ParentId", "Right" },
                values: new object[,]
                {
                    { new Guid("6418ce5b-a4b7-4cf3-9d96-7081282c24a7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 60, "", "Packaged", "Packaged Ingredient", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, null, 4 },
                    { new Guid("8b2a5b54-dd87-49f7-af52-db6fcc973db6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 30, "", "Processed", "Processed Ingredient", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, null, 2 }
                });
        }
    }
}
