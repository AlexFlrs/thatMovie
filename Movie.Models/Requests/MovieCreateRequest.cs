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
        
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string MovieImage { get; set; }
    }
}
