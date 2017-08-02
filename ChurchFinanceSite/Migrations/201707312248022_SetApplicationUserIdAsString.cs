namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetApplicationUserIdAsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Givers", "ApplicationUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Givers", "ApplicationUserId", c => c.Int(nullable: false));
        }
    }
}
