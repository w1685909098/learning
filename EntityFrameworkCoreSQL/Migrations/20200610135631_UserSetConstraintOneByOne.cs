using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreSQL.Migrations
{
    public partial class UserSetConstraintOneByOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailId",
                table: "User",
                column: "EmailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Email_EmailId",
                table: "User",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Email_EmailId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropIndex(
                name: "IX_User_EmailId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "User");
        }
    }
}
