using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Data.Migrations
{
    public partial class EnrolName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrolName",
                columns: table => new
                {
                    EnrolName_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_Id = table.Column<int>(type: "int", nullable: true),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolName", x => x.EnrolName_Id);
                    table.ForeignKey(
                        name: "FK_EnrolName_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnrolName_Student_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Student",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolName_Course_Id",
                table: "EnrolName",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolName_Student_Id",
                table: "EnrolName",
                column: "Student_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolName");
        }
    }
}
