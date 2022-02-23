using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Data.Migrations
{
    public partial class Removedbadnigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "Student_Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Course_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Course_Id",
                table: "Courses",
                newName: "ID");
        }
    }
}
