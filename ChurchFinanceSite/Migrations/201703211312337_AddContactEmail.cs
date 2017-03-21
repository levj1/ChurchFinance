namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactEmails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Comment = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactEmails");
        }
    }
}
