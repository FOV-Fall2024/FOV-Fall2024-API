using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDomainV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Cập nhật kiểu dữ liệu với câu lệnh USING
            migrationBuilder.Sql("ALTER TABLE \"Orders\" ALTER COLUMN \"OrderType\" TYPE smallint USING \"OrderType\"::smallint;");

            migrationBuilder.Sql("ALTER TABLE \"Orders\" ALTER COLUMN \"OrderStatus\" TYPE smallint USING \"OrderStatus\"::smallint;");

            migrationBuilder.Sql("ALTER TABLE \"OrderDetails\" ALTER COLUMN \"Status\" TYPE smallint USING \"Status\"::smallint;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Quay lại kiểu dữ liệu ban đầu
            migrationBuilder.Sql("ALTER TABLE \"Orders\" ALTER COLUMN \"OrderType\" TYPE text USING \"OrderType\"::text;");

            migrationBuilder.Sql("ALTER TABLE \"Orders\" ALTER COLUMN \"OrderStatus\" TYPE text USING \"OrderStatus\"::text;");

            migrationBuilder.Sql("ALTER TABLE \"OrderDetails\" ALTER COLUMN \"Status\" TYPE text USING \"Status\"::text;");

            // Xóa cột 'Quantity' nếu cần
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductIngredients");
        }
    }
}
