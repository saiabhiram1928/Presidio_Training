using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeReqTrackerModelLibrary.Migrations
{
    public partial class Request_moidification3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "Requests",
                newName: "RequestId");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 15, 8, 28, 30, 762, DateTimeKind.Local).AddTicks(3694));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Requests",
                newName: "RequestNumber");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestNumber",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 14, 22, 33, 34, 440, DateTimeKind.Local).AddTicks(5315));
        }
    }
}
