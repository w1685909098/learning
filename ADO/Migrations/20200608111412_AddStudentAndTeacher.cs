using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class AddStudentAndTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bedroom_BedId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BedId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BedId1",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentAndTeacher",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAndTeacher", x => new { x.StudentId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_StudentAndTeacher_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAndTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAndTeacher_TeacherId",
                table: "StudentAndTeacher",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAndTeacher");

            migrationBuilder.AddColumn<int>(
                name: "BedId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BedId1",
                table: "Students",
                column: "BedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bedroom_BedId1",
                table: "Students",
                column: "BedId1",
                principalTable: "Bedroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
