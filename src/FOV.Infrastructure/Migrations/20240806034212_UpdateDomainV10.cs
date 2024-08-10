using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomainV10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductGeneralId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGeneralId",
                table: "Products",
                column: "ProductGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGenerals_ProductGeneralId",
                table: "Products",
                column: "ProductGeneralId",
                principalTable: "ProductGenerals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGenerals_ProductGeneralId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGeneralId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGeneralId",
                table: "Products");
        }
    }
}
