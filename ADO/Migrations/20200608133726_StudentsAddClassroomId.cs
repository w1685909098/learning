using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class StudentsAddClassroomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classroom_ClassroomId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classroom_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classroom_ClassroomId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classroom_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
