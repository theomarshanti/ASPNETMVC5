namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUpdatedCustomerModel5 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate=null WHERE Name!='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
