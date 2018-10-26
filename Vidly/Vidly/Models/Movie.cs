using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage ="The field Number in Stock must be between 1 and 20")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set;  }

        [Display(Name = "Number Available")]
        public int NumberAvailable { get; set; }
    }
}