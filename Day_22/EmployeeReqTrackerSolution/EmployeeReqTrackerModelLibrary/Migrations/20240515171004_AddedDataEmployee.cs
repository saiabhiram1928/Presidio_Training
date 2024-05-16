using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeReqTrackerModelLibrary.Migrations
{
    public partial class AddedDataEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 101, "test1", "test1123", "Admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 102, "test2", "test2123", "user" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 103, "test3", "test3123", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103);
        }
    }
}
