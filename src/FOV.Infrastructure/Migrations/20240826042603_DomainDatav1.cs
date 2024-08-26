using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainDatav1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductIngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientGeneralId",
                value: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductIngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IngredientGeneralId",
                value: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"));
        }
    }
}
