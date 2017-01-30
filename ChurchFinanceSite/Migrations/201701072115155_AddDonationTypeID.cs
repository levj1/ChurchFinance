namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonationTypeID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "DonationTypeID_ID", c => c.Int());
            CreateIndex("dbo.Donations", "DonationTypeID_ID");
            AddForeignKey("dbo.Donations", "DonationTypeID_ID", "dbo.DonationTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "DonationTypeID_ID", "dbo.DonationTypes");
            DropIndex("dbo.Donations", new[] { "DonationTypeID_ID" });
            DropColumn("dbo.Donations", "DonationTypeID_ID");
        }
    }
}
