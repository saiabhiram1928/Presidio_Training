using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeReqTrackerModelLibrary.Migrations
{
    public partial class sol_data_modfication2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 17, 11, 20, 49, 764, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Solutions",
                keyColumn: "Id",
                keyValue: 1,
                column: "SolvedBy",
                value: 101);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 5, 17, 11, 17, 16, 890, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Solutions",
                keyColumn: "Id",
                keyValue: 1,
                column: "SolvedBy",
                value: 102);
        }
    }
}
