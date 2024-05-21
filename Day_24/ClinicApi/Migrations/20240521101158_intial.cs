using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name", "Specialization" },
                values: new object[] { 101, 2, "Doctor 1", "Cardio" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name", "Specialization" },
                values: new object[] { 102, 3, "Doctor 2", "Radio" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name", "Specialization" },
                values: new object[] { 103, 6, "Doctor 3", "Radio" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
