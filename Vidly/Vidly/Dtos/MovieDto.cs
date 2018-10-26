﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}