namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieModelGenre : DbMigration
    {
        public override void Up()
        {
//            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 128));
  //          CreateIndex("dbo.Movies", "Name");
    //        AddForeignKey("dbo.Movies", "Name", "dbo.Genres", "Name", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
//            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
//            DropIndex("dbo.Movies", new[] { "Name" });
//            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
    }
}
