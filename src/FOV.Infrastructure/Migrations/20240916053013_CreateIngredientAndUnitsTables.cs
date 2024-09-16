using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateIngredientAndUnitsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "numeric", nullable: false),
                    IngredientUnitParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientUnit_IngredientUnit_IngredientUnitParentId",
                        column: x => x.IngredientUnitParentId,
                        principalTable: "IngredientUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientUnit_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 16, 5, 30, 12, 508, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUnit_IngredientId",
                table: "IngredientUnit",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUnit_IngredientUnitParentId",
                table: "IngredientUnit",
                column: "IngredientUnitParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUnit");

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 15, 16, 12, 55, 544, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                column: "ExpiredDate",
                value: new DateTime(2024, 11, 15, 16, 12, 55, 544, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                column: "ExpiredDate",
                value: new DateTime(2024, 10, 15, 16, 12, 55, 544, DateTimeKind.Utc).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                column: "HireDate",
                value: new DateTime(2024, 9, 15, 16, 12, 55, 545, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                column: "HireDate",
                value: new DateTime(2024, 9, 15, 16, 12, 55, 545, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                column: "HireDate",
                value: new DateTime(2024, 9, 15, 16, 12, 55, 545, DateTimeKind.Utc).AddTicks(3848));
        }
    }
}
