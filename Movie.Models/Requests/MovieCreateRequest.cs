using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models.Requests
{
    public class MovieCreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Actors { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Rated { get; set; }
    }
}
