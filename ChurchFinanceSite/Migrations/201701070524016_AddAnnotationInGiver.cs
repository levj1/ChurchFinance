namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationInGiver : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Givers", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Givers", "Middle", c => c.String(maxLength: 30));
            AlterColumn("dbo.Givers", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String(maxLength: 30));
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String(maxLength: 30));
            AlterColumn("dbo.Addresses", "City", c => c.String(maxLength: 30));
            AlterColumn("dbo.Addresses", "State", c => c.String(maxLength: 30));
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
            AlterColumn("dbo.Addresses", "State", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String());
            AlterColumn("dbo.Givers", "LastName", c => c.String());
            AlterColumn("dbo.Givers", "Middle", c => c.String());
            AlterColumn("dbo.Givers", "FirstName", c => c.String());
        }
    }
}
