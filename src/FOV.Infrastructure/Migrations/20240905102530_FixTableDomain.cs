using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTableDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the columns that will be removed
            migrationBuilder.DropColumn(
                name: "TableDescription",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "TableImage",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "TableState",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "TableType",
                table: "Tables");

            // Change column type with raw SQL
            migrationBuilder.Sql(
                "ALTER TABLE \"Tables\" ALTER COLUMN \"TableStatus\" TYPE smallint USING CASE " +
                "WHEN \"TableStatus\" = 'Status1' THEN 1 " +
                "WHEN \"TableStatus\" = 'Status2' THEN 2 " +
                "ELSE 0 END;");

            migrationBuilder.Sql(
                "ALTER TABLE \"Tables\" ALTER COLUMN \"TableNumber\" TYPE integer USING CASE " +
                "WHEN \"TableNumber\" ~ '^[0-9]+$' THEN CAST(\"TableNumber\" AS integer) " +
                "ELSE 0 END;");

            migrationBuilder.AlterColumn<byte>(
                name: "TableStatus",
                table: "Tables",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TableNumber",
                table: "Tables",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            // Update existing data
            migrationBuilder.Sql(
                "UPDATE \"Tables\" SET \"TableStatus\" = COALESCE(\"TableStatus\", 0);");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 10, 25, 29, 383, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 10, 25, 29, 383, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 5, 10, 25, 29, 383, DateTimeKind.Utc).AddTicks(276));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverse the column type changes
            migrationBuilder.AlterColumn<string>(
                name: "TableStatus",
                table: "Tables",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "TableNumber",
                table: "Tables",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            // Add the dropped columns back
            migrationBuilder.AddColumn<string>(
                name: "TableDescription",
                table: "Tables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableImage",
                table: "Tables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableState",
                table: "Tables",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableType",
                table: "Tables",
                type: "text",
                nullable: true);

            // Reverse the data updates
            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 5, 9, 55, 31, 396, DateTimeKind.Utc).AddTicks(2766));
        }
    }
}
