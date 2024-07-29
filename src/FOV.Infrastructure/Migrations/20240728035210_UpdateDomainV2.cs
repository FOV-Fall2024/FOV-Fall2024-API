using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGeneral_Category_CategoryId",
                table: "ProductGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredientGeneral_IngredientGenerals_IngredientGener~",
                table: "ProductIngredientGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredientGeneral_ProductGeneral_ProductGeneralId",
                table: "ProductIngredientGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductIngredientGeneral",
                table: "ProductIngredientGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGeneral",
                table: "ProductGeneral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "ProductIngredientGeneral",
                newName: "ProductIngredientGenerals");

            migrationBuilder.RenameTable(
                name: "ProductGeneral",
                newName: "ProductGenerals");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredientGeneral_ProductGeneralId",
                table: "ProductIngredientGenerals",
                newName: "IX_ProductIngredientGenerals_ProductGeneralId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredientGeneral_IngredientGeneralId",
                table: "ProductIngredientGenerals",
                newName: "IX_ProductIngredientGenerals_IngredientGeneralId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGeneral_CategoryId",
                table: "ProductGenerals",
                newName: "IX_ProductGenerals_CategoryId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Ingredients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ingredients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Ingredients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Ingredients",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGeneralId",
                table: "ProductIngredientGenerals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientGeneralId",
                table: "ProductIngredientGenerals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ProductIngredientGenerals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ProductGenerals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryParentId",
                table: "Categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryMain",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductIngredientGenerals",
                table: "ProductIngredientGenerals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGenerals",
                table: "ProductGenerals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGenerals_Categories_CategoryId",
                table: "ProductGenerals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredientGenerals_IngredientGenerals_IngredientGene~",
                table: "ProductIngredientGenerals",
                column: "IngredientGeneralId",
                principalTable: "IngredientGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredientGenerals_ProductGenerals_ProductGeneralId",
                table: "ProductIngredientGenerals",
                column: "ProductGeneralId",
                principalTable: "ProductGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGenerals_Categories_CategoryId",
                table: "ProductGenerals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredientGenerals_IngredientGenerals_IngredientGene~",
                table: "ProductIngredientGenerals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredientGenerals_ProductGenerals_ProductGeneralId",
                table: "ProductIngredientGenerals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductIngredientGenerals",
                table: "ProductIngredientGenerals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGenerals",
                table: "ProductGenerals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductIngredientGenerals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "ProductIngredientGenerals",
                newName: "ProductIngredientGeneral");

            migrationBuilder.RenameTable(
                name: "ProductGenerals",
                newName: "ProductGeneral");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredientGenerals_ProductGeneralId",
                table: "ProductIngredientGeneral",
                newName: "IX_ProductIngredientGeneral_ProductGeneralId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredientGenerals_IngredientGeneralId",
                table: "ProductIngredientGeneral",
                newName: "IX_ProductIngredientGeneral_IngredientGeneralId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGenerals_CategoryId",
                table: "ProductGeneral",
                newName: "IX_ProductGeneral_CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductGeneralId",
                table: "ProductIngredientGeneral",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientGeneralId",
                table: "ProductIngredientGeneral",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "ProductGeneral",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryParentId",
                table: "Category",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryMain",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductIngredientGeneral",
                table: "ProductIngredientGeneral",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGeneral",
                table: "ProductGeneral",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGeneral_Category_CategoryId",
                table: "ProductGeneral",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredientGeneral_IngredientGenerals_IngredientGener~",
                table: "ProductIngredientGeneral",
                column: "IngredientGeneralId",
                principalTable: "IngredientGenerals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredientGeneral_ProductGeneral_ProductGeneralId",
                table: "ProductIngredientGeneral",
                column: "ProductGeneralId",
                principalTable: "ProductGeneral",
                principalColumn: "Id");
        }
    }
}
