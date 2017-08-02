namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegistrationAndAddressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Givers", "ApplicationUserIdNonForeignKey", c => c.String());
            DropColumn("dbo.Givers", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Givers", "ApplicationUserId", c => c.String());
            DropColumn("dbo.Givers", "ApplicationUserIdNonForeignKey");
        }
    }
}
