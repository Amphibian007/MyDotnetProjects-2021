using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CreateCountryDTO
    {
        
        [Required(ErrorMessage ="Country should be entered")]
        [StringLength (maximumLength:50,ErrorMessage ="Country is too long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country short name should be entered")]
        [StringLength(maximumLength: 3, ErrorMessage = "Country short name is too long")]
        public string ShortName { get; set; }
    }
    public class CountryDTO:CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }
}
