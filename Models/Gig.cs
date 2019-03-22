using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GHub.Models
{
    public class Gig
    {
        // who performs, when, where?
        public int Id { get; set; }

        //[Required]
        public ApplicationUser Artist { get; set; } // artist should not be nullable so it's required

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        //[Required]
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

    }
}