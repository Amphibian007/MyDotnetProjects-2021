using HotelListing.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CreateHotelDTO
    {
       
        [Required(ErrorMessage ="Hotel name should be entered")]
        [StringLength(maximumLength:100,ErrorMessage ="Name is too long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address should be entered")]
       
        public string Address { get; set; }
        [Required(ErrorMessage = "Hotel name should be entered")]
        [Range(1,5,ErrorMessage ="From 1 to 5")]
        public double Rating { get; set; }
        [Required(ErrorMessage ="Country should be selected")]
       
        public int CountryId { get; set; }
    }
    public class HotelDTO:CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
