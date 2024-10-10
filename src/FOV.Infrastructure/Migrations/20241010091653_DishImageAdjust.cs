using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DishImageAdjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "DishGenerals");

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Dishes",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.CreateTable(
                name: "DishGeneralImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DishGeneralId = table.Column<Guid>(type: "uuid", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishGeneralImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishGeneralImages_DishGenerals_DishGeneralId",
                        column: x => x.DishGeneralId,
                        principalTable: "DishGenerals",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.CreateIndex(
                name: "IX_DishGeneralImages_DishGeneralId",
                table: "DishGeneralImages",
                column: "DishGeneralId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishGeneralImages");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Dishes");

            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "DishGenerals",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "Images",
                value: new string[0]);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "Images",
                value: new string[0]);
        }
    }
}
