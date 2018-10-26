namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Rentals", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "CustomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Rentals", "Movie_Id");
            DropColumn("dbo.Rentals", "Customer_Id");
        }
    }
}
