using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchemaV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTransactions_Dishes_DishId",
                table: "IngredientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTransactions_DishId",
                table: "IngredientTransactions");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "IngredientTransactions");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientMeasureId",
                table: "Ingredients",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 11, 14, 57, 34, 14, DateTimeKind.Utc).AddTicks(218), new DateTime(2024, 11, 11, 14, 57, 34, 14, DateTimeKind.Utc).AddTicks(219) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 11, 14, 57, 34, 14, DateTimeKind.Utc).AddTicks(228), new DateTime(2024, 11, 11, 14, 57, 34, 14, DateTimeKind.Utc).AddTicks(228) });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId",
                principalTable: "IngredientMeasures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.AddColumn<Guid>(
                name: "DishId",
                table: "IngredientTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientMeasureId",
                table: "Ingredients",
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
                values: new object[] { new DateTime(2024, 11, 11, 12, 23, 6, 122, DateTimeKind.Utc).AddTicks(5913), new DateTime(2024, 11, 11, 12, 23, 6, 122, DateTimeKind.Utc).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 11, 12, 23, 6, 122, DateTimeKind.Utc).AddTicks(5924), new DateTime(2024, 11, 11, 12, 23, 6, 122, DateTimeKind.Utc).AddTicks(5924) });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTransactions_DishId",
                table: "IngredientTransactions",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId",
                principalTable: "IngredientMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTransactions_Dishes_DishId",
                table: "IngredientTransactions",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
