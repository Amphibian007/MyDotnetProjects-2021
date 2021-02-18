using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsList.Models
{
    public class Sport
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*Name must be enterd")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Price must be enterd")]
        [Range(1,20000,ErrorMessage ="*Range should be beween 1 to 20000")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "*Rating must be enterd")]
        [Range(1, 5, ErrorMessage = "*Rating should be beween 1 to 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "*Type must be enterd")]
        public int? TypeId { get; set; }
        public Type Type { get; set; }
    }
}
