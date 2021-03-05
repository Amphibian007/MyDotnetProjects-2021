using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DollarCalculator.Models
{
    public class DollarModel
    {

        [Required(ErrorMessage ="This is required")]
        public decimal? MonthlyAsset { get; set; }
        [Required(ErrorMessage = "This is required")]
        public decimal? YearlyInterestRate { get; set; }
        [Required(ErrorMessage = "This is required")]
        public decimal? Years { get; set; }
        public decimal Calculate()
        {
            decimal futureDollar = 0;
            var months = Years.Value* 12;
            var monthlyInterestRate = YearlyInterestRate / 12 / 100;
            for(int i = 0; i < months; i++)
            {
                futureDollar = (futureDollar + MonthlyAsset.Value) * (1 + monthlyInterestRate.Value);
            }
            return futureDollar;
        }
    }
}
