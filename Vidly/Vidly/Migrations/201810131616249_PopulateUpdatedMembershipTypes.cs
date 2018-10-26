namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUpdatedMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE DurationInMonths=0");
            Sql(@"UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths!=0");
        }
        
        public override void Down()
        {
        }
    }
}
