using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameList.Models
{
    public class Game
    {     
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the name")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the year")]
        [Range(1990,2021,ErrorMessage ="Between 1990 to 2021")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please enter the rating")]
        [Range(1, 5, ErrorMessage = "Between 1 to 5")]
        public int? Rating { get; set; }
    }
}
