using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityStudentsApp.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AditionalPoints",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalPoints",
                table: "Enrollment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalPoints",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "AditionalPoints",
                table: "Enrollment",
                type: "int",
                nullable: true);
        }
    }
}
