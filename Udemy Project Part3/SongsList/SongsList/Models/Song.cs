using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Song name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Time is required")]
        [Range(1920,2021,ErrorMessage ="Range should be from 1920 to 2021")]
        public int? Year { get; set; }
        [Required(ErrorMessage ="You should give the rating")]
        [Range(1,5,ErrorMessage ="Rating range is 1 to 5")]
        public int? Rating { get; set; }
    }
}
