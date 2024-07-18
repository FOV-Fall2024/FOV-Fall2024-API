using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IngredientDomainv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IngredientTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "IngredientGenerals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "IngredientGenerals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IngredientDescription",
                table: "IngredientGenerals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IngredientGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "IngredientGenerals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "IngredientGenerals",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IngredientTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "IngredientDescription",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "IngredientGenerals");
        }
    }
}
