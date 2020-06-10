using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreSQL.Migrations
{
    public partial class UserSetConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Id = table.Column<int>(nullable: false),
                    InvitedBy = table.Column<string>(nullable: true),
                    InvitationCode = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    VerificationCode = table.Column<int>(nullable: false),
                    helpMoney = table.Column<int>(nullable: false),
                    HelpBean = table.Column<int>(nullable: false),
                    HelpCredit = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CreateTime",
                table: "User",
                column: "CreateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpBean = table.Column<int>(type: "int", nullable: false),
                    HelpCredit = table.Column<int>(type: "int", nullable: false),
                    InvitationCode = table.Column<int>(type: "int", nullable: false),
                    InvitedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationCode = table.Column<int>(type: "int", nullable: false),
                    helpMoney = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
