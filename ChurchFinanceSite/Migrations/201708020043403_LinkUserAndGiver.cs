namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkUserAndGiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Givers", "AppUserId", c => c.String());
            CreateIndex("dbo.Addresses", "ApplicationUserId");
            AddForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Givers", "ApplicationUserIdNonForeignKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Givers", "ApplicationUserIdNonForeignKey", c => c.String());
            DropForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "ApplicationUserId" });
            DropColumn("dbo.Givers", "AppUserId");
            DropColumn("dbo.Addresses", "ApplicationUserId");
        }
    }
}
