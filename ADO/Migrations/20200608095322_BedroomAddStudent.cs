using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharp.Migrations
{
    public partial class BedroomAddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bedroom_BedId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BedId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "BedId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BedId1",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BedId",
                table: "Students",
                column: "BedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BedId1",
                table: "Students",
                column: "BedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bedroom_BedId",
                table: "Students",
                column: "BedId",
                principalTable: "Bedroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bedroom_BedId1",
                table: "Students",
                column: "BedId1",
                principalTable: "Bedroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bedroom_BedId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Bedroom_BedId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BedId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_BedId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BedId1",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "BedId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Students_BedId",
                table: "Students",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Bedroom_BedId",
                table: "Students",
                column: "BedId",
                principalTable: "Bedroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
