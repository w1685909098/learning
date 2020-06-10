using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreSQL.Migrations
{
    public partial class UserAddFailedTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedTry",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedTry",
                table: "Users");
        }
    }
}
