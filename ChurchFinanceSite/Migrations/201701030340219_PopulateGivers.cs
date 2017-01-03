namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGivers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO givers (FirstName, Middle, LastName, AddressId) Values ('James', '', 'Leveille', '3')");
            Sql("INSERT INTO givers (FirstName, Middle, LastName, AddressId) Values ('Emmanuella', 'Jean Pierre', 'Leveille', '2')");
            Sql("INSERT INTO givers (FirstName, Middle, LastName, AddressId) Values ('FirstTest', 'MiddleTest', 'LastTest', '1')");
            Sql("INSERT INTO givers (FirstName, Middle, LastName, AddressId) Values ('Barbara', '', 'Andrew', '5')");
            Sql("INSERT INTO givers (FirstName, Middle, LastName, AddressId) Values ('Peter', 'Steve', 'Louis', '4')");
        }
        
        public override void Down()
        {
        }
    }
}
