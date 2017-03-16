namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonationAddProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "DonationUpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donations", "DonationUpdatedDate");
        }
    }
}
