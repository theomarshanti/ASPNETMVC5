namespace Vidly.Migrations
{
    //This is incorrecrlt named. This is just an explicit population of the 1st customer table.. Mosh did this manually
    // by hand, but we dewcided to codify it for practice.
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUpdatedCustomerModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('John Smith', 0, 1)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES ('Mary Williams', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
