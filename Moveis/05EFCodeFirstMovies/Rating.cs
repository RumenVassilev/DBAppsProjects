using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _05EFCodeFirstMovies
{
    public class Rating
    {
        public int Id { get; set; }

        
        public int Stars { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }

        //[ForeignKey("Movie")]
        public int MovieId { get; set; }
    }
}
