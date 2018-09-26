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
        [Required, MaxLength]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required, MaxLength]
        public string Actors { get; set; }
        [Required, MaxLength]
        public string Description { get; set; }
        [Required, MaxLength]
        public string MovieImage { get; set; }
    }
}
