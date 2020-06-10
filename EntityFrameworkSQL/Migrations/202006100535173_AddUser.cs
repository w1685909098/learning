namespace EntityFrameworkSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvitedBy = c.String(),
                        InvitationCode = c.Int(nullable: false),
                        Name = c.String(),
                        VerificationCode = c.Int(nullable: false),
                        helpMoney = c.Int(nullable: false),
                        HelpBean = c.Int(nullable: false),
                        HelpCredit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
