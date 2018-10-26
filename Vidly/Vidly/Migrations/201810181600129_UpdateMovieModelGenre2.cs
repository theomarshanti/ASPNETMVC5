namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieModelGenre2 : DbMigration
    {
        public override void Up()
        { 
        }

        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
        }
    }
}
