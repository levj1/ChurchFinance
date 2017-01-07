namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDataIntoDonationType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into DonationTypes(Name) Values('Offering')");
            Sql("Insert into DonationTypes(Name) Values('Tithe')");
            Sql("Insert into DonationTypes(Name) Values('Pledge')");
            Sql("Insert into DonationTypes(Name) Values('Mission')");
            Sql("Insert into DonationTypes(Name) Values('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
