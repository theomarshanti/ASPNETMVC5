namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES('Hangover', 'Comedy', 'November 6, 2009', 'May 4, 2016', 5)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES('Die Hard', 'Acion', 'November 7, 2009', 'May 5, 2016', 6)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES('The Terminator', 'Action', 'November 8, 2009', 'May 6, 2016', 7)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES('Toy Story', 'Family', 'November 9, 2009', 'May 7, 2016', 8)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "VALUES('Titanic', 'Romance', 'November 10, 2009', 'May 8, 2016', 9)");
        }
        
        public override void Down()
        {
        }
    }
}
