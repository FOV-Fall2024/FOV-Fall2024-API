using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AttendanceWaiterDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Combo_ComboId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombo_Combo_ComboId",
                table: "ProductCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombo_Products_ProductId",
                table: "ProductCombo");

            migrationBuilder.DropForeignKey(
                name: "FK_Table_Restaurant_RestaurantId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCombo",
                table: "ProductCombo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "ProductCombo",
                newName: "ProductCombos");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Table_RestaurantId",
                table: "Tables",
                newName: "IX_Tables_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombo_ProductId",
                table: "ProductCombos",
                newName: "IX_ProductCombos_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombo_ComboId",
                table: "ProductCombos",
                newName: "IX_ProductCombos_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ComboId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TableId",
                table: "Orders",
                newName: "IX_Orders_TableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCombos",
                table: "ProductCombos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftName = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaiterSalary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalHours = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaiterSalary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaiterSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaiterSchedule_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WaiterSchedule_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId1 = table.Column<string>(type: "text", nullable: true),
                    WaiterScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_AspNetUsers_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attendances_WaiterSchedule_WaiterScheduleId",
                        column: x => x.WaiterScheduleId,
                        principalTable: "WaiterSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId1",
                table: "Attendances",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_WaiterScheduleId",
                table: "Attendances",
                column: "WaiterScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSalary_UserId",
                table: "WaiterSalary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSchedule_ShiftId",
                table: "WaiterSchedule",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSchedule_UserId",
                table: "WaiterSchedule",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Combo_ComboId",
                table: "OrderDetails",
                column: "ComboId",
                principalTable: "Combo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombos_Combo_ComboId",
                table: "ProductCombos",
                column: "ComboId",
                principalTable: "Combo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombos_Products_ProductId",
                table: "ProductCombos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurant_RestaurantId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Combo_ComboId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombos_Combo_ComboId",
                table: "ProductCombos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCombos_Products_ProductId",
                table: "ProductCombos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurant_RestaurantId",
                table: "Tables");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "WaiterSalary");

            migrationBuilder.DropTable(
                name: "WaiterSchedule");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCombos",
                table: "ProductCombos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameTable(
                name: "ProductCombos",
                newName: "ProductCombo");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_RestaurantId",
                table: "Table",
                newName: "IX_Table_RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombos_ProductId",
                table: "ProductCombo",
                newName: "IX_ProductCombo_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCombos_ComboId",
                table: "ProductCombo",
                newName: "IX_ProductCombo_ComboId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TableId",
                table: "Order",
                newName: "IX_Order_TableId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ComboId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ComboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCombo",
                table: "ProductCombo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Combo_ComboId",
                table: "OrderDetail",
                column: "ComboId",
                principalTable: "Combo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombo_Combo_ComboId",
                table: "ProductCombo",
                column: "ComboId",
                principalTable: "Combo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCombo_Products_ProductId",
                table: "ProductCombo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Restaurant_RestaurantId",
                table: "Table",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
