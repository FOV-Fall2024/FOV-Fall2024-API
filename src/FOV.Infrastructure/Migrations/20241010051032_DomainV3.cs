using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DishGeneralId",
                table: "DishImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DishImages_DishGeneralId",
                table: "DishImages",
                column: "DishGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishImages_DishGenerals_DishGeneralId",
                table: "DishImages",
                column: "DishGeneralId",
                principalTable: "DishGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishImages_DishGenerals_DishGeneralId",
                table: "DishImages");

            migrationBuilder.DropIndex(
                name: "IX_DishImages_DishGeneralId",
                table: "DishImages");

            migrationBuilder.DropColumn(
                name: "DishGeneralId",
                table: "DishImages");
        }
    }
}
