using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1990,2021,ErrorMessage ="Movies should be from the time 1990 to 2021")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 10, ErrorMessage = "Rating should be from the time 1 to 10")]
        public int? Rating { get; set; }
        [Required(ErrorMessage ="Genre should be selected from the dropdown")]
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
