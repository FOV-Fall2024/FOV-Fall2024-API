using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientMeasure",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientMeasure",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "DishIngredientStatus",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "DishGenerals");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientMeasureId",
                table: "Ingredients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientMeasureId",
                table: "IngredientGenerals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DishGeneralParentId",
                table: "DishGenerals",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientMeasureName = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeasures", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a0"),
                column: "IngredientMeasureId",
                value: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"));

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
                column: "IngredientMeasureId",
                value: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"));

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientMeasureId",
                value: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"));

            migrationBuilder.InsertData(
                table: "IngredientMeasures",
                columns: new[] { "Id", "Created", "CreatedBy", "IngredientMeasureName", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"), new DateTime(2024, 11, 11, 10, 51, 44, 9, DateTimeKind.Utc).AddTicks(4214), null, "gam", new DateTime(2024, 11, 11, 10, 51, 44, 9, DateTimeKind.Utc).AddTicks(4216), null },
                    { new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"), new DateTime(2024, 11, 11, 10, 51, 44, 9, DateTimeKind.Utc).AddTicks(4224), null, "ml", new DateTime(2024, 11, 11, 10, 51, 44, 9, DateTimeKind.Utc).AddTicks(4224), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientGenerals_IngredientMeasureId",
                table: "IngredientGenerals",
                column: "IngredientMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DishGenerals_DishGeneralParentId",
                table: "DishGenerals",
                column: "DishGeneralParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishGenerals_DishGenerals_DishGeneralParentId",
                table: "DishGenerals",
                column: "DishGeneralParentId",
                principalTable: "DishGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGenerals_IngredientMeasures_IngredientMeasureId",
                table: "IngredientGenerals",
                column: "IngredientMeasureId",
                principalTable: "IngredientMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients",
                column: "IngredientMeasureId",
                principalTable: "IngredientMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishGenerals_DishGenerals_DishGeneralParentId",
                table: "DishGenerals");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGenerals_IngredientMeasures_IngredientMeasureId",
                table: "IngredientGenerals");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientMeasures_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "IngredientMeasures");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_IngredientGenerals_IngredientMeasureId",
                table: "IngredientGenerals");

            migrationBuilder.DropIndex(
                name: "IX_DishGenerals_DishGeneralParentId",
                table: "DishGenerals");

            migrationBuilder.DropColumn(
                name: "IngredientMeasureId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientMeasureId",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "DishGeneralParentId",
                table: "DishGenerals");

            migrationBuilder.AddColumn<byte>(
                name: "IngredientMeasure",
                table: "Ingredients",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IngredientMeasure",
                table: "IngredientGenerals",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DishIngredientStatus",
                table: "DishIngredients",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "DishGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a0"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
                column: "IngredientMeasure",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientMeasure",
                value: (byte)0);
        }
    }
}
