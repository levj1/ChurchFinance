namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToGiverModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Givers", "ApplicationUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Givers", "ApplicationUserId");
        }
    }
}
