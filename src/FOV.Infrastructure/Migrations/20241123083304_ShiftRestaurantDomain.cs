using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShiftRestaurantDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShiftRestaurant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftRestaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftRestaurant_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShiftRestaurant_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 33, 4, 153, DateTimeKind.Utc).AddTicks(8724), new DateTime(2024, 11, 23, 8, 33, 4, 153, DateTimeKind.Utc).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 33, 4, 153, DateTimeKind.Utc).AddTicks(8732), new DateTime(2024, 11, 23, 8, 33, 4, 153, DateTimeKind.Utc).AddTicks(8733) });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRestaurant_RestaurantId",
                table: "ShiftRestaurant",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftRestaurant_ShiftId",
                table: "ShiftRestaurant",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftRestaurant");

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6182a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4781), new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "IngredientMeasures",
                keyColumn: "Id",
                keyValue: new Guid("6531296e-a86a-4fcc-97e7-7e6192a5c011"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4786), new DateTime(2024, 11, 23, 6, 6, 15, 868, DateTimeKind.Utc).AddTicks(4786) });
        }
    }
}
