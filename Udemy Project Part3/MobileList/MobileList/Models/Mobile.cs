using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileList.Models
{
    public class Mobile
    {     
        public int Id { get; set; }
        [Required (ErrorMessage ="Name must be entered")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price must be entered")]
        [Range(5000,20000,ErrorMessage ="Between 5000 and 20000")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Rating must be entered")]
        [Range(1, 5, ErrorMessage = "Between 1 and 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage = "Company name must be entered")]
        public int? CompanyId { get; set; }     
        public Company Company { get; set; }
    }
}
