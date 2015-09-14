using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05EFCodeFirstMovies
{
    public class User
    {
        private ICollection<Movie> movies;
        private ICollection<Rating> ratings;

        public User()
        {
            this.movies = new HashSet<Movie>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public string Email { get; set; }

        public int? age { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int MovieId { get; set; }

        public virtual ICollection<Movie> Movies
        {   
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<Rating> Ratings 
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
