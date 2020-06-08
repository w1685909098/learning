using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class StudentToBedroomOneByOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Bedroom",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bedroom_StudentsId",
                table: "Bedroom",
                column: "StudentsId",
                unique: true,
                filter: "[StudentsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bedroom_Students_StudentsId",
                table: "Bedroom",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bedroom_Students_StudentsId",
                table: "Bedroom");

            migrationBuilder.DropIndex(
                name: "IX_Bedroom_StudentsId",
                table: "Bedroom");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Bedroom");
        }
    }
}
