using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveComboSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Combos",
                columns: new[] { "Id", "ComboDescription", "ComboName", "ComboStatus", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PercentReduce", "Price", "RestaurantId", "Status", "Thumbnail" },
                values: new object[,]
                {
                    { new Guid("3907a193-c2ae-4f40-936b-9a2438595123"), null, "Combo 2", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 5.0m, 30.00m, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)1, "img2" },
                    { new Guid("921b269a-db6e-4a1d-b285-70df523e010e"), null, "Combo 3", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 5.0m, 30.00m, new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"), (byte)1, "img3" },
                    { new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"), null, "Combo 1", (byte)0, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, 10.0m, 50.00m, new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"), (byte)1, "img1" }
                });
        }
    }
}
