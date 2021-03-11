using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        [Required(ErrorMessage ="Song name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Year should be enterd")]
        [Range(1990, 2021, ErrorMessage = "Range should be  between 1990 and 2010")]
        public int? Year { get; set; }
        [Required(ErrorMessage ="Range is required")]
        [Range(1,5,ErrorMessage ="Range should be from 1 to 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage ="Please select genre from the dropdown")]
        public int TypeId { get; set; }
        public Type Type { get; set; }

    }
}
