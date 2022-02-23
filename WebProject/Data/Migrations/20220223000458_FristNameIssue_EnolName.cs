using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Data.Migrations
{
    public partial class FristNameIssue_EnolName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Name",
                table: "EnrolName",
                newName: "First_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "EnrolName",
                newName: "Student_Name");
        }
    }
}
