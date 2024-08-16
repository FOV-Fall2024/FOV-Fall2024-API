using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixShiftDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSalary_AspNetUsers_UserId",
                table: "WaiterSalary");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WaiterSalary",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shift",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSalary_AspNetUsers_UserId",
                table: "WaiterSalary",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSalary_AspNetUsers_UserId",
                table: "WaiterSalary");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shift");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WaiterSalary",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSalary_AspNetUsers_UserId",
                table: "WaiterSalary",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
