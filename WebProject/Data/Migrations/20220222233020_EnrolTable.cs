using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Data.Migrations
{
    public partial class EnrolTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrol",
                columns: table => new
                {
                    Enrol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrol", x => x.Enrol_Id);
                    table.ForeignKey(
                        name: "FK_Enrol_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrol_Student_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Student",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrol_Course_Id",
                table: "Enrol",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrol_Student_Id",
                table: "Enrol",
                column: "Student_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrol");
        }
    }
}
