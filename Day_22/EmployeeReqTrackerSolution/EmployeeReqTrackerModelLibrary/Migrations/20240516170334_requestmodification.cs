using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeReqTrackerModelLibrary.Migrations
{
    public partial class requestmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestNumber", "ClosedDate", "RequestClosedBy", "RequestDate", "RequestMessage", "RequestRaisedBy", "RequestStatus" },
                values: new object[] { 1, null, null, new DateTime(2024, 5, 14, 22, 33, 34, 440, DateTimeKind.Local).AddTicks(5315), "Laptop Repair", 102, "Open" });

            migrationBuilder.InsertData(
                table: "Solutions",
                columns: new[] { "Id", "IsSolutionAccepted", "RequestId", "RequestRaiserComment", "SolutionText", "SolvedBy", "SolvedDate" },
                values: new object[] { 1, false, 1, "Checked it", "Check Bois", 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Solutions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "RequestNumber",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "RequestClosedBy",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
