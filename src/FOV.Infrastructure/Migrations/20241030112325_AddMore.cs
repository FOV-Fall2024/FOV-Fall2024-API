using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddMore",
                table: "OrderDetails",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddMore",
                table: "OrderDetails");
        }
    }
}
