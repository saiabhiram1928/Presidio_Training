using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeReqTrackerModelLibrary.Migrations
{
    public partial class Request_moidification5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 15, 8, 54, 9, 989, DateTimeKind.Local).AddTicks(4369));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 15, 8, 36, 8, 75, DateTimeKind.Local).AddTicks(4700));
        }
    }
}
