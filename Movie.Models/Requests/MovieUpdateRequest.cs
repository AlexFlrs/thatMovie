using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models.Requests
{
    public class MovieUpdateRequest : MovieCreateRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
