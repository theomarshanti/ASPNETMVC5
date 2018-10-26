namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUpdatedCustomerModel2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='01/01/1980' WHERE Name='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
