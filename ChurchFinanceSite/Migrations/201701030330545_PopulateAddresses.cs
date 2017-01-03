namespace ChurchFinanceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAddresses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Addresses (AddressLine1, AddressLine2, City, State, Zipcode) Values ('123 Street ave', 'Apt #1', 'VilleLa', 'Maryland', '12345')");
            Sql("INSERT INTO Addresses (AddressLine1, AddressLine2, City, State, Zipcode) Values ('1245 Sheridan ave', 'Apt #2', 'Greenbel', 'Virginia', '23145')");
            Sql("INSERT INTO Addresses (AddressLine1, AddressLine2, City, State, Zipcode) Values ('561 Columbia way', 'Apt #3', 'Silver Spring', 'DC', '12785')");
            Sql("INSERT INTO Addresses (AddressLine1, AddressLine2, City, State, Zipcode) Values ('13607 Colgate way', 'Apt #4', 'Centerville', 'Georgia', '98345')");
            Sql("INSERT INTO Addresses (AddressLine1, AddressLine2, City, State, Zipcode) Values ('54th Street', 'Apt #5', 'WayVille', 'North Carolina', '89345')");
        }
        
        public override void Down()
        {
        }
    }
}
