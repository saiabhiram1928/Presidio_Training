using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaShoppingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Customers_CustomerId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Pizzas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CustomerId", "InStock", "Name", "Price" },
                values: new object[,]
                {
                    { 101, null, true, "Margherita", 150m },
                    { 102, null, true, "Pepperoni", 170m },
                    { 103, null, true, "Capsicum Veg", 180m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Customers_CustomerId",
                table: "Pizzas",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Customers_CustomerId",
                table: "Pizzas");

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Customers_CustomerId",
                table: "Pizzas",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
