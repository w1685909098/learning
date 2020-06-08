using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class ClassroomDeleteStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Students_SId",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_SId",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Classroom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Classroom",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_SId",
                table: "Classroom",
                column: "SId",
                unique: true,
                filter: "[SId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Students_SId",
                table: "Classroom",
                column: "SId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
