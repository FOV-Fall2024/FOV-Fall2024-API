using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainV13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombo_Combos_ComboId",
                table: "ProductCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombo_Products_ProductId",
                table: "ProductCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCombo",
                table: "ProductCombo");

            migrationBuilder.RenameTable(
                name: "ProductCombo",
                newName: "ProductCombos");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombo_ProductId",
                table: "ProductCombos",
                newName: "IX_ProductCombos_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombo_ComboId",
                table: "ProductCombos",
                newName: "IX_ProductCombos_ComboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCombos",
                table: "ProductCombos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombos_Combos_ComboId",
                table: "ProductCombos",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombos_Products_ProductId",
                table: "ProductCombos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombos_Combos_ComboId",
                table: "ProductCombos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombos_Products_ProductId",
                table: "ProductCombos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCombos",
                table: "ProductCombos");

            migrationBuilder.RenameTable(
                name: "ProductCombos",
                newName: "ProductCombo");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombos_ProductId",
                table: "ProductCombo",
                newName: "IX_ProductCombo_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombos_ComboId",
                table: "ProductCombo",
                newName: "IX_ProductCombo_ComboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCombo",
                table: "ProductCombo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombo_Combos_ComboId",
                table: "ProductCombo",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombo_Products_ProductId",
                table: "ProductCombo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
