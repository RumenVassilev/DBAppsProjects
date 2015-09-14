using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _05EFCodeFirstMovies
{
    public class Movie
    {
        private ICollection<User> users;

        public Movie()
        {
            this.Users = this.users;
        }
        public int Id { get; set; }

        [Required]
        public int Isbn { get; set; }

        public Rating Rating { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Title { get; set; }

        public ICollection<User> Users { get; set; }

        public AgeRestriction AgeRestriction { get; set; }
    }
}
