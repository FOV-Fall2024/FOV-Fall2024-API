using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FOV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IngredientTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IngredientTransactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IngredientGenerals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishIngredientGenerals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishGenerals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DishCombos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Tables",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Shifts",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "VnpTxnRef",
                table: "Payments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "IngredientTypes",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "IngredientTransactions",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "DishIngredientGenerals",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "DishGenerals",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Dishes",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "DishCombos",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Customers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ComboStatus",
                table: "Combos",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Categories",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                columns: new[] { "ComboStatus", "Status" },
                values: new object[] { (byte)0, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                columns: new[] { "ComboStatus", "Status" },
                values: new object[] { (byte)0, (byte)1 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                columns: new[] { "ComboStatus", "Status" },
                values: new object[] { (byte)0, (byte)1 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DishIngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "Status",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"),
                column: "Status",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"),
                column: "Status",
                value: (byte)1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IngredientTypes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IngredientTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DishIngredientGenerals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DishGenerals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DishCombos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ComboStatus",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tables",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shifts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Restaurants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "VnpTxnRef",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IngredientTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IngredientTransactions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IngredientGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishIngredientGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishGenerals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dishes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DishCombos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Combos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("3907a193-c2ae-4f40-936b-9a2438595123"),
                columns: new[] { "IsDeleted", "Status" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("921b269a-db6e-4a1d-b285-70df523e010e"),
                columns: new[] { "IsDeleted", "Status" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "Combos",
                keyColumn: "Id",
                keyValue: new Guid("941bcca9-52a6-41f7-9403-06cc5fa703ea"),
                columns: new[] { "IsDeleted", "Status" },
                values: new object[] { false, (byte)0 });

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishGenerals",
                keyColumn: "Id",
                keyValue: new Guid("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "DishIngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: new Guid("e311d82d-452c-4603-a029-762a2a4e5e19"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientGenerals",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f66bab-13c9-4390-8582-545ddc7d2ec8"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                column: "IsDeleted",
                value: false);
        }
    }
}
