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
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Combos",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                columns: new[] { "ExpiredDate", "Thumbnail" },
                values: new object[] { new DateTime(2024, 12, 3, 14, 47, 20, 356, DateTimeKind.Utc).AddTicks(1831), null });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                columns: new[] { "ExpiredDate", "Thumbnail" },
                values: new object[] { new DateTime(2024, 12, 3, 14, 47, 20, 356, DateTimeKind.Utc).AddTicks(1834), null });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                columns: new[] { "ExpiredDate", "Thumbnail" },
                values: new object[] { new DateTime(2024, 11, 3, 14, 47, 20, 356, DateTimeKind.Utc).AddTicks(1817), null });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 10, 14, 47, 20, 363, DateTimeKind.Unspecified).AddTicks(1833), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 10, 14, 47, 20, 363, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Combos");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 3, 11, 46, 28, 684, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 12, 3, 11, 46, 28, 684, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 3, 11, 46, 28, 684, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 10, 11, 46, 28, 691, DateTimeKind.Unspecified).AddTicks(4759), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "ReleaseDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 10, 11, 46, 28, 691, DateTimeKind.Unspecified).AddTicks(4796), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
