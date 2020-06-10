using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreSQL.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvitedBy = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VerificationCode = table.Column<int>(nullable: false),
                    helpMoney = table.Column<int>(nullable: false),
                    HelpBean = table.Column<int>(nullable: false),
                    HelpCredit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
