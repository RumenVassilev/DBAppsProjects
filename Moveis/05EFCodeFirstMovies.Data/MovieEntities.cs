namespace _05EFCodeFirstMovies.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieEntities : DbContext
    {
        public MovieEntities()
            : base("name=MovieEntities")
        {
            Database.SetInitializer
                (new MigrateDatabaseToLatestVersion<MovieEntities, _05EFCodeFirstMovies.Data.Migrations.Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
    }
}