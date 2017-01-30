namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedonationTypeid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "DonationTypeID_ID", "dbo.DonationTypes");
            DropForeignKey("dbo.Donations", "DonationType_ID", "dbo.DonationTypes");
            DropIndex("dbo.Donations", new[] { "DonationType_ID" });
            DropIndex("dbo.Donations", new[] { "DonationTypeID_ID" });
            RenameColumn(table: "dbo.Donations", name: "DonationType_ID", newName: "DonationTypeID");
            AlterColumn("dbo.Donations", "DonationTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Donations", "DonationTypeID");
            AddForeignKey("dbo.Donations", "DonationTypeID", "dbo.DonationTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.Donations", "DonationTypeID_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donations", "DonationTypeID_ID", c => c.Int());
            DropForeignKey("dbo.Donations", "DonationTypeID", "dbo.DonationTypes");
            DropIndex("dbo.Donations", new[] { "DonationTypeID" });
            AlterColumn("dbo.Donations", "DonationTypeID", c => c.Int());
            RenameColumn(table: "dbo.Donations", name: "DonationTypeID", newName: "DonationType_ID");
            CreateIndex("dbo.Donations", "DonationTypeID_ID");
            CreateIndex("dbo.Donations", "DonationType_ID");
            AddForeignKey("dbo.Donations", "DonationType_ID", "dbo.DonationTypes", "ID");
            AddForeignKey("dbo.Donations", "DonationTypeID_ID", "dbo.DonationTypes", "ID");
        }
    }
}
