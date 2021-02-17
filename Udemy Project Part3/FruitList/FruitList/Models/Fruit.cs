using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitList.Models
{
    public class Fruit
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of the fruit is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Year is required")]
        [Range(2001,2010,ErrorMessage ="Between 2001 to 2010")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Between 1 and 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "Genre should be entered")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Slug => Name?.Replace(' ', '_').ToLower() + "_" + Year.ToString();
      
    }
}
