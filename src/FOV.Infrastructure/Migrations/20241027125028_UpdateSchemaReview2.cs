using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaReview2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "GroupMessages");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "NewDishRecommendLogs");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "NewDishRecommends");

            migrationBuilder.DropIndex(
                name: "IX_WaiterSchedules_EmployeeId",
                table: "WaiterSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientTypeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Attendances");

            migrationBuilder.AddColumn<Guid>(
                name: "DishId",
                table: "IngredientTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientRequestId",
                table: "IngredientTransactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientGeneralId",
                table: "Ingredients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Attendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Attendances",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "AspNetUsers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "IngredientRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestCode = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRequests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTransactions_DishId",
                table: "IngredientTransactions",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTransactions_IngredientRequestId",
                table: "IngredientTransactions",
                column: "IngredientRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientGeneralId",
                table: "Ingredients",
                column: "IngredientGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restaurants_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId1",
                table: "Attendances",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGenerals_IngredientGeneralId",
                table: "Ingredients",
                column: "IngredientGeneralId",
                principalTable: "IngredientGenerals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTransactions_Dishes_DishId",
                table: "IngredientTransactions",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTransactions_IngredientRequests_IngredientRequest~",
                table: "IngredientTransactions",
                column: "IngredientRequestId",
                principalTable: "IngredientRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Restaurants_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId1",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGenerals_IngredientGeneralId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTransactions_Dishes_DishId",
                table: "IngredientTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTransactions_IngredientRequests_IngredientRequest~",
                table: "IngredientTransactions");

            migrationBuilder.DropTable(
                name: "IngredientRequests");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTransactions_DishId",
                table: "IngredientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTransactions_IngredientRequestId",
                table: "IngredientTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientGeneralId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId1",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "IngredientTransactions");

            migrationBuilder.DropColumn(
                name: "IngredientRequestId",
                table: "IngredientTransactions");

            migrationBuilder.DropColumn(
                name: "IngredientGeneralId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "Ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientTypeId",
                table: "Ingredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Dishes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Attendances",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Attendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    EmployeeCode = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    GroupName = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupChats_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewDishRecommends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DishGeneralId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDishRecommends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewDishRecommends_DishGenerals_DishGeneralId",
                        column: x => x.DishGeneralId,
                        principalTable: "DishGenerals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDishRecommends_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMessages_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUsers_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewDishRecommendLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewDishRecommendId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LogDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LogType = table.Column<byte>(type: "smallint", nullable: false),
                    NewProductRecommendId = table.Column<Guid>(type: "uuid", nullable: false),
                    NewProductRecommendLogStatus = table.Column<byte>(type: "smallint", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDishRecommendLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewDishRecommendLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDishRecommendLogs_NewDishRecommends_NewDishRecommendId",
                        column: x => x.NewDishRecommendId,
                        principalTable: "NewDishRecommends",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GroupChats",
                columns: new[] { "Id", "Created", "CreatedBy", "GroupName", "LastModified", "LastModifiedBy", "RestaurantId" },
                values: new object[] { new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0110b0"), new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, "DefaultGroupChat", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0") });

            migrationBuilder.CreateIndex(
                name: "IX_WaiterSchedules_EmployeeId",
                table: "WaiterSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RestaurantId",
                table: "Employees",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_RestaurantId",
                table: "GroupChats",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_GroupChatId",
                table: "GroupMessages",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_UserId",
                table: "GroupMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupChatId",
                table: "GroupUsers",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDishRecommendLogs_NewDishRecommendId",
                table: "NewDishRecommendLogs",
                column: "NewDishRecommendId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDishRecommendLogs_UserId",
                table: "NewDishRecommendLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDishRecommends_DishGeneralId",
                table: "NewDishRecommends",
                column: "DishGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDishRecommends_RestaurantId",
                table: "NewDishRecommends",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                table: "Attendances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientTypes_IngredientTypeId",
                table: "Ingredients",
                column: "IngredientTypeId",
                principalTable: "IngredientTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiterSchedules_Employees_EmployeeId",
                table: "WaiterSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
