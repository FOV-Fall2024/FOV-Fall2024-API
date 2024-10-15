using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIngredientUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefundDishUnits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefundDishUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundDishInventoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefundDishUnitParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConversionFactor = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    UnitName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundDishUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundDishUnits_RefundDishInventories_RefundDishInventoryId",
                        column: x => x.RefundDishInventoryId,
                        principalTable: "RefundDishInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefundDishUnits_RefundDishUnits_RefundDishUnitParentId",
                        column: x => x.RefundDishUnitParentId,
                        principalTable: "RefundDishUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishUnits_RefundDishInventoryId",
                table: "RefundDishUnits",
                column: "RefundDishInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundDishUnits_RefundDishUnitParentId",
                table: "RefundDishUnits",
                column: "RefundDishUnitParentId");
        }
    }
}
