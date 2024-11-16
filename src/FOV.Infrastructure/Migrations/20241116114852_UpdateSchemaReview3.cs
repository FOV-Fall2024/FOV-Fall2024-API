using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaReview3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1359), new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1366), new DateTime(2024, 11, 16, 11, 48, 51, 459, DateTimeKind.Utc).AddTicks(1366) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IngredientMeasureId",
                table: "Ingredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 14, 13, 32, 15, 646, DateTimeKind.Utc).AddTicks(866), new DateTime(2024, 11, 14, 13, 32, 15, 646, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 14, 13, 32, 15, 646, DateTimeKind.Utc).AddTicks(874), new DateTime(2024, 11, 14, 13, 32, 15, 646, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId",
                principalTable: "IngredientMeasures",
                principalColumn: "Id");
        }
    }
}
