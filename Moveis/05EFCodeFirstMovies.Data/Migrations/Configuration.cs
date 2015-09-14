namespace _05EFCodeFirstMovies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_05EFCodeFirstMovies.Data.MovieEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_05EFCodeFirstMovies.Data.MovieEntities";
        }

        protected override void Seed(_05EFCodeFirstMovies.Data.MovieEntities context)
        {
            // What ever I do I just can't run the Seed. It keeps telling me that a Library can't be run, which is impossible
            // because I've done the migration correctly. I added the DB and when I try to make changes it keeps giving me error.
            // I've done every possible reference between the console client, data and models but it just doesn't work.
            // I can't even test the connections between the tables...
        }
    }
}
