namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DonationDate = c.DateTime(nullable: false),
                        GiverID = c.Int(nullable: false),
                        DonationType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonationTypes", t => t.DonationType_ID)
                .ForeignKey("dbo.Givers", t => t.GiverID, cascadeDelete: true)
                .Index(t => t.GiverID)
                .Index(t => t.DonationType_ID);
            
            CreateTable(
                "dbo.DonationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "GiverID", "dbo.Givers");
            DropForeignKey("dbo.Donations", "DonationType_ID", "dbo.DonationTypes");
            DropIndex("dbo.Donations", new[] { "DonationType_ID" });
            DropIndex("dbo.Donations", new[] { "GiverID" });
            DropTable("dbo.DonationTypes");
            DropTable("dbo.Donations");
        }
    }
}
